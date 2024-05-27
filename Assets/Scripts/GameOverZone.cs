using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverZone : MonoBehaviour
{
    public string sceneToOpen;
    void OnTriggerEnter2D(Collider2D obj)
    {

        if (obj.gameObject.tag == "Player")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToOpen);
        }
    }
}
