using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroyObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Object.DontDestroyOnLoad(this.gameObject);
    }

    
}
