using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DogEnemybehaviour : EnemyBehaviour
{
    //Enum thatis provide to show what direction there can go;
    public enum moveDir{east, west, south, north, stop};

    //The current direction they are going at
    public moveDir currDir;
    public moveDir oppDir;
    public GameObject popupDamagePrefab;
    public TMP_Text popUptext;
    public SpriteRenderer sr;


    
    public override void movement()
    {
        //if(!disturb)
        //{
        switch(currDir)
        {
            
            case moveDir.east:
                rb.velocity = new Vector2(speed, 0.0f);
                oppDir = moveDir.west;
                sr.flipX=true;
                break;
            case moveDir.west:
                rb.velocity = new Vector2(-speed, 0.0f);
                oppDir = moveDir.east;
                sr.flipX=false;
                break;
            case moveDir.north:
                rb.velocity = new Vector2(0.0f, speed);
                oppDir = moveDir.south;
                break;
            case moveDir.south:
                rb.velocity = new Vector2(0.0f, -speed);
                oppDir = moveDir.north;
                break;
            case moveDir.stop:
                rb.velocity = new Vector2(0.0f, 0.0f);
                break;
            default:
                currDir = moveDir.stop;
                break;
        }
       // }
    }

    public override void damage(int a, string tag)
    {
        if(tag == "Water")
        {
            irratationlvl -= a;
            if(currency > 0.0f)
            {
                
                GameObject money = Instantiate(moneyPickup, transform.position, transform.rotation) as GameObject;
                money.GetComponent<MoneyPickupScript>().hold = currency;
            }
            else
            {
                moneyChance();
            }
            currDir = oppDir;
            disturb = true;
            StartCoroutine(reset(1.0f));
        }
        //if(irratationlvl <= 0)
        //{
            

            //Destroy(gameObject);
        //}
    }


    public void moneyChance()
    {
        if(!disturb)
        {
        GameObject money = Instantiate(moneyPickup, transform.position, transform.rotation) as GameObject;
        popUptext.text = "50";
        money.GetComponent<MoneyPickupScript>().hold = 50.0f;
        Instantiate(popupDamagePrefab, transform.position, Quaternion.identity);
        }
    }

    IEnumerator reset(float t)
    {
        anim.Play("Dog_Hurt");
        rb.velocity = new Vector2(0.0f, 0.0f);
        yield return new WaitForSeconds(10.0f);
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
