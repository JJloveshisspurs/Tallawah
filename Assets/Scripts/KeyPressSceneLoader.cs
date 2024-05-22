using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyPressSceneLoader : MonoBehaviour
{
    public string sceneToLoadOnKeyPress;

    bool keyPressed = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey && keyPressed == false)
        {
            keyPressed = true;
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoadOnKeyPress);
        }
    }
}
