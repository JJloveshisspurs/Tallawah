using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationScript : MonoBehaviour
{
    public SpriteRenderer sr;
    public Animator anim;
    private TopDownMovement top;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        top = GetComponent<TopDownMovement>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!GetComponent<AssistButton>().assistActive)
        {
        if(Input.GetKey("down"))
        {
            anim.Play("downMoving");
        }
        else if(top.lastButton == "down")
        {
            anim.Play("downIdle");
        }
        
        


        if(Input.GetKey("up") )
        {
            anim.Play("UpMoving");
        }
        else if(top.lastButton == "up" )
        {
            anim.Play("UpIdle");
        }

        if(Input.GetKey("left") )
        {
            anim.Play("LeftMoving");
        }
        else if(top.lastButton == "left" )
        {
            anim.Play("LeftIdle");
        }

         if(Input.GetKey("right") )
        {
            anim.Play("rightMoving");
        }
        else if(top.lastButton == "right")
        {
            anim.Play("rightIdle");
        }

        }

    }
}
