using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashPickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    

    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "Player")
        {
            if (obj.gameObject.GetComponent<InventoryScript>() != null)
            {
                obj.gameObject.GetComponent<InventoryScript>().trash += 1;
                Counter.instance.IncreaseCoins(1);
                Destroy(gameObject);
            }
        }
    }
}
