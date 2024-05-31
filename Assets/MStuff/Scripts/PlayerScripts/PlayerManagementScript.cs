using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This hold the player currency, shield, and if the player is invinicible

public class PlayerManagementScript : MonoBehaviour
{
    //This will be shields instead of hp and instead of shield will be purchaseable
    public int shield = 0;

    //This check if the character can be hit again if false
    public bool invincible = false;

    //This hold the amount of money the character have
    public float currency = 1000.00f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //The damage function is for how much money the enemy takes away
    public void Damage(float p, EnemyBehaviour eb)
    {
        if(!invincible)
        {
            if(shield > 0 )
            {
                shield--;
            }
            else
            {
                int moneyout = Mathf.FloorToInt(currency *p);
                currency -= moneyout;
                eb.currency += moneyout;
                invincible = true; 
            }
            StartCoroutine(damageReset());
        }
    }

    IEnumerator damageReset()
    {
        StartCoroutine(showIFrame());
        yield return new WaitForSeconds(3.0f);
        invincible = false;
    }

    IEnumerator showIFrame()
    {
        while(invincible)
        {
            yield return new WaitForSeconds(0.05f);
            if(GetComponent<SpriteRenderer>().enabled)
            {
                GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                GetComponent<SpriteRenderer>().enabled = true;
            }
        }
         yield return new WaitForSeconds(0.3f);
         GetComponent<SpriteRenderer>().enabled = true;

    }
}
