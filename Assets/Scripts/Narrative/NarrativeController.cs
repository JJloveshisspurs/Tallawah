using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NarrativeController : MonoBehaviour
{

    public string sceneToLoadOnNarrativeComplete;

    public List<GameObject> narrativePages;

    public int NarrativePanelIndex = -1;

    public float delayBetweenPanels = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DisplayCheckForNextPanel()
    {

        NarrativePanelIndex = NarrativePanelIndex + 1;





       



        if(NarrativePanelIndex < narrativePages.Count)
        {

          

        }
        else
        {

            Debug.Log("Completed Narrative Panels! Loading next scene");



            LoadNextScene();
        }
        

        
    }


    public void ClearandRenderCorrectNarrativePanel()
    {
        for(int i = 0; i < narrativePages.Count; i++)
        {
            if (NarrativePanelIndex < narrativePages.Count)
                narrativePages[i].SetActive(false);

        }

        if(NarrativePanelIndex < narrativePages.Count)
        narrativePages[NarrativePanelIndex].SetActive(true);


        
    }

    public void LoadNextScene()
    {

        StopAllCoroutines();
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoadOnNarrativeComplete);

    }

    public void FinishedPrintingNarrativeText()
    {
        DisplayCheckForNextPanel();
        ClearandRenderCorrectNarrativePanel();

    }
}
