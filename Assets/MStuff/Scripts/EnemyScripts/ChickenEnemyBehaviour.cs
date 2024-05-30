using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChickenEnemyBehaviour : EnemyBehaviour
{
    public GameObject popupDamagePrefab;
    public TMP_Text popUptext;
    public override void damage(int a, string tag)
    {
        if(tag == "Water")
        {
            irratationlvl -= a;
            disturb = true;
            StartCoroutine(reset(1.0f));
        }
        if(irratationlvl <= 0)
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

    IEnumerator reset(float t)
    {
        //anim.Play("Dog_Hurt");
        //rb.velocity = new Vector2(0.0f, 0.0f);
        yield return new WaitForSeconds(t);
        //anim.Play("Dog_Idle");
        disturb = false; 
    }

    public void moneyChance()
    {
        GameObject money = Instantiate(moneyPickup, transform.position, transform.rotation) as GameObject;
        popUptext.text = "50";
        money.GetComponent<MoneyPickupScript>().hold = 50.0f;
        Instantiate(popupDamagePrefab, transform.position, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if(!disturb)
        {
            if(obj.gameObject.tag =="Player")
            {
                if (obj.gameObject.GetComponent<PlayerManagementScript>() != null)
                {
                    obj.gameObject.GetComponent<PlayerManagementScript>().Damage(dPercentage, GetComponent<ChickenEnemyBehaviour>());


                    Debug.Log("Last year");
                }
            }

            
        }
    }
}
