using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSender : MonoBehaviour
{
    public float delayBeforeTextRender;
    public List<NarrativeTextItem> dialogue;
    public NarrativeTextRenderer textRenderer;

    public void OnEnable()
    {
        Invoke("SetDialogue", delayBeforeTextRender);
    }


    public void SetDialogue()
    {

        textRenderer.SetDialogue(dialogue);

    }
}
