using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitKeyboardShortcut : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Q )|| Input.GetKey(KeyCode.Escape)){

            Application.Quit();
        }
    }
}
