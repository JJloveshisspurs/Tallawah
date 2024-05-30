using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPickupScript : MonoBehaviour
{
    public float hold = 0.0f;
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
        if (obj.gameObject.tag == "Player")
        {
            if (obj.gameObject.GetComponent<PlayerManagementScript>() != null)
            {
                obj.gameObject.GetComponent<PlayerManagementScript>().currency += hold;

                Destroy(gameObject);
             }
    }
    }
}
