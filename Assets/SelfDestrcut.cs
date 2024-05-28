using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SelfDestrcut : MonoBehaviour
{
     private float timer;
     public float destroyTime;

    // Start is called before the first frame update
    void Start()
    {
        timer = destroyTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        
        if(timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
