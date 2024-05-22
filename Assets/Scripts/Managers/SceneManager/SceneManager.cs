using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static SceneManager instance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
    }

    
}
