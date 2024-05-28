using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssistButton : MonoBehaviour
{
    public bool assistActive = false;
    public float assistGuage = 50.0f;
    public float assistGuageLimit = 50.0f;
    public float rate= 1.0f;
    public GameObject cousin;

    private bool finishLoading = true;

    private GameObject temp; 
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(assistGuage > assistGuageLimit)
        {
            assistGuage = 50.0f;
            finishLoading = true;
        }
        if(Input.GetKeyDown("x"))
        {
            anim.Play("Player_Assist");
            finishLoading = false;   
            assistGuage = 0.0f; 
        }

        if(!finishLoading)
        {
            assistGuage += Time.deltaTime*rate;
        }


    }



    public void pause()
    {
        Time.timeScale = 0f;
        temp = Instantiate(cousin,transform.position, transform.rotation) as GameObject;
    }

    public void unpause()
    {
        Time.timeScale = 1.0f;
        Destroy(temp);
        Debug.Log("yo");
    }

    IEnumerator assistPower()
    {
        GetComponent<InteractionButtonScript>().additionalPower = 3;
        yield return new WaitForSeconds(30f);
        GetComponent<InteractionButtonScript>().additionalPower = 0;
    }
}
