using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogEnemybehaviour : EnemyBehaviour
{
    //Enum thatis provide to show what direction there can go;
    public enum moveDir{east, west, south, north, stop};

    //The current direction they are going at
    public moveDir currDir;

    
    public override void movement()
    {
        if(!disturb)
        {
        switch(currDir)
        {
            
            case moveDir.east:
                rb.velocity = new Vector2(speed, 0.0f);
                break;
            case moveDir.west:
                rb.velocity = new Vector2(-speed, 0.0f);
                break;
            case moveDir.north:
                rb.velocity = new Vector2(0.0f, speed);
                break;
            case moveDir.south:
                rb.velocity = new Vector2(0.0f, -speed);
                break;
            case moveDir.stop:
                rb.velocity = new Vector2(0.0f, 0.0f);
                break;
            default:
                currDir = moveDir.stop;
                break;
        }
        }
    }

    public override void damage(float disturbTime, string tag)
    {
        if(tag == "Water")
        {
            irratationlvl -= 10;
            disturb = true;
            StartCoroutine(reset(disturbTime));
        }
        if(irratationlvl == 0)
        {
            if(currency > 0.0f)
            {
                GameObject money = Instantiate(moneyPickup, transform.position, transform.rotation) as GameObject;
                money.GetComponent<MoneyPickupScript>().hold = currency;
            }
            else
            {
                moneyChance();
            }
            Destroy(gameObject);
        }
    }


    public void moneyChance()
    {
        GameObject money = Instantiate(moneyPickup, transform.position, transform.rotation) as GameObject;
        money.GetComponent<MoneyPickupScript>().hold = 50.0f;
    }

    IEnumerator reset(float t)
    {
        anim.Play("Dog_Hurt");
        rb.velocity = new Vector2(0.0f, 0.0f);
        yield return new WaitForSeconds(t);
        anim.Play("Dog_Idle");
        disturb = false; 
    }
    void OnTriggerEnter2D(Collider2D obj)
    {
        if(!disturb)
        {
            if(obj.gameObject.tag =="Player")
            {   
                obj.gameObject.GetComponent<PlayerManagementScript>().Damage(dPercentage, GetComponent<DogEnemybehaviour>());
                Debug.Log("Last year");
            }

            
        }
    }
   
}
