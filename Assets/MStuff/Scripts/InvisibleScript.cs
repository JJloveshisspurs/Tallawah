using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        makeInvisible();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void makeInvisible()
    {
        GetComponent<SpriteRenderer>().enabled=false;
        foreach(Transform child in transform)
        {
            child.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
