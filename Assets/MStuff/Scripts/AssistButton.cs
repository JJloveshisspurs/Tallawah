using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssistButton : MonoBehaviour
{
    public bool assistActive = false;
    public float assistGuage = 0.0f;
    public float assistGuageLimit = 50.0f;
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
        }
        if(Input.GetKeyDown("x"))
        {
            anim.Play("Player_Assist");
        }
    }

    public void pause()
    {
        Time.timeScale = 0f;

    }

    public void unpause()
    {
        Time.timeScale = 1.0f;
        Debug.Log("yo");
    }
}
