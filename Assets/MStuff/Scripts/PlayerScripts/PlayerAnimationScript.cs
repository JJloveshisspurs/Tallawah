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
        if(rb.velocity.x < 0.0f)
        {
            sr.flipX = true;
        }
        else if(rb.velocity.x > 0.0f)
        {
            sr.flipX = false;
        }
        if(rb.velocity.y == 0.0f && rb.velocity.x == 0.0f)
        {
            anim.SetBool("Moving", false);
        }
        else
        {
            anim.SetBool("Moving", true);
        }
    }
}
