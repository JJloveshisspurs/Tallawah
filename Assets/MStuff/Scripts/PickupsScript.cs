using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsScript : MonoBehaviour
{    
    public GameObject text;
    
    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "Player")
        {
            text.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D obj)
    {
        if(obj.gameObject.tag == "Player")
        {
            text.SetActive(false);
        }
    }
}
