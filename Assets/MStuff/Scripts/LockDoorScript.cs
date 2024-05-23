using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDoorScript : MonoBehaviour
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
        if(obj.gameObject.tag =="Player")
        {
            if(obj.gameObject.GetComponent<InventoryScript>().keys > 0)
            {
                obj.gameObject.GetComponent<InventoryScript>().keys--;
                Destroy(gameObject);
            }
        }
    }
}
