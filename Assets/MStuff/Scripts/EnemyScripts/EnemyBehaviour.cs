using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    //Essentially a life bar
    public int irratationlvl = 10;

    //Speed of movement
    public float speed = 1.0f;

    //Component that is needed
    public Rigidbody2D rb;

    //
    public bool disturb = false;

    //The amount of money it takes away from the player
    public float dPercentage = 0.005f;

    //Currency that the enemy holded
    public float currency = 0.0f;

    //Component that is for animation
    public Animator anim;

    public GameObject moneyPickup;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    public virtual void movement()
    {

    }

    public virtual void damage(int disturbTime, string tag)
    {
        
    }

}
