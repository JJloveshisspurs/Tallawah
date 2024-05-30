using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnenable : MonoBehaviour
{

    public List<GameObject> gameObjects;
    private void OnEnable()
    {
        for(int i = 0; i < gameObjects.Count; i++)
        {

            gameObjects[i].SetActive(true);

        }
    }
}
