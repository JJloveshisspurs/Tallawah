using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int value;


    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.CompareTag("Player"))
        {
           
            Destroy(gameObject);
            Counter.instance.IncreaseCoins(value);

        }
        else if(other.gameObject.CompareTag("badCoin"))
        {
            Destroy(gameObject);
            Counter.instance.DecreaseCoins(value);
        }
       
      
    }
}
