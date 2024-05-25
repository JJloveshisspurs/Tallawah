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
        StartCoroutine(DisplayNextPanel());
    }

    IEnumerator DisplayNextPanel()
    {

        NarrativePanelIndex = NarrativePanelIndex + 1;





        yield return new WaitForSeconds(delayBetweenPanels);



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

            narrativePages[i].SetActive(false);

        }


        narrativePages[NarrativePanelIndex].SetActive(true);


        StartCoroutine(DisplayNextPanel());
    }

    public void LoadNextScene()
    {

        StopAllCoroutines();
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoadOnNarrativeComplete);

    }

    public void FinishedPrintingNarrativeText()
    {

        ClearandRenderCorrectNarrativePanel();

    }
}
