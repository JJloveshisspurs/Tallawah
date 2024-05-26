using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;

public class NarrativeTextRenderer : MonoBehaviour
{
    public TextMeshPro textField_CharacterName;
    public TextMeshPro textField_Dialogue;
    public List<NarrativeTextItem> dialogue;


    public float textPrintRate = .02f;
    public float pauseBetweenDialogUpdates = 3f;

    public NarrativeController narrativeController;

    public int dialogueblockTextIndex;
    public int dialogueLetterIndex;
    public int characterLetterIndex;

    public bool testDialogueOnStart = false;

    public void Start()
    {
        /*if (testDialogueOnStart)
            TestDialogue();*/
    }

    public void TestDialogue()
    {

        List<NarrativeTextItem> testDialogue = new List<NarrativeTextItem>();

        NarrativeTextItem narrativeItem1 = new NarrativeTextItem();
        narrativeItem1.characterName = "Rasta man";
        narrativeItem1.dialogue = " *kiss teeth* Too much gyabidge deh a Jamaica. If we nuh love & cherish Mada Earth, oo will?";

        testDialogue.Add(narrativeItem1);

        NarrativeTextItem narrativeItem2 = new NarrativeTextItem();
        narrativeItem2.characterName = "S";
        narrativeItem2.dialogue = "…";

        testDialogue.Add(narrativeItem2);


        SetDialogue(testDialogue);

    }

    public void SetDialogue(List<NarrativeTextItem> narrativetext)
    {
        dialogueblockTextIndex = 0;
        dialogue = narrativetext;

        StartCoroutine(IterateThroughText());
    }


    IEnumerator IterateThroughText()
    {

        yield return new WaitForSeconds(textPrintRate);

        PrintNextLetter();

    }

    public void FinishedIteratingThroughtext()
    {

        narrativeController.FinishedPrintingNarrativeText();


    }

    public void PrintNextLetter()
    {

       if(textField_CharacterName.text != dialogue[dialogueblockTextIndex].characterName)
        {

            textField_CharacterName.text = dialogue[dialogueblockTextIndex].characterName;

        }




        dialogueLetterIndex = dialogueLetterIndex + 1;

        textField_Dialogue.text = dialogue[dialogueblockTextIndex].dialogue.Substring(0, dialogueLetterIndex);

        if(textField_Dialogue.text.Length >= dialogue[dialogueblockTextIndex].dialogue.Length)
        {

            StartCoroutine(PauseBetweenTextblocks());

        }
        else
        {

            StartCoroutine(IterateThroughText());


        }

    }

    IEnumerator PauseBetweenTextblocks()
    {


        yield return new WaitForSeconds(pauseBetweenDialogUpdates);

        PrinteNextDialogueBlock();
    }

    public void PrinteNextDialogueBlock()
    {
        dialogueblockTextIndex = dialogueblockTextIndex + 1;
        dialogueLetterIndex = 0;

        if (dialogueblockTextIndex >= dialogue.Count)
        {

            MoveToNextPage();
        }
        else
        {
            StartCoroutine(IterateThroughText());
        }
    }

    public void MoveToNextPage()
    {

        Debug.Log("Moving to the Next Page!!!!");
        narrativeController.FinishedPrintingNarrativeText();
    }
}
