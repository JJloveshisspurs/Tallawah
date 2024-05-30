using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueElementRenderer 
{
    public int dialogue_Page;
    public int dialogueBlock;
    public GameObject objectToActivate;

    public void ActivateObject()
    {

        objectToActivate.SetActive(true);
    }
}
