using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private SpriteRenderer sr;
    [Header("Input")]
    [Tooltip("Input any key to move your the gameObject left. If left empty it will automatically " +
        "pick the left arrow key")]
    public string LeftButton;
    [Tooltip("Input any key to move your the gameObject right. If left empty it will automatically " +
        "pick the right arrow key")]
    public string RightButton;
    [Tooltip("Input any key to move your the gameObject up. If left empty it will automatically " +
        "pick the up arrow key")]
    public string UpButton;
    [Tooltip("Input any key to move your the gameObject down. If left empty it will automatically " +
        "pick the down arrow key")]
    public string DownButton;

    [Header("Components")]
    [Tooltip("This script needs a rigidbody2D to work, it will automatically gets if on the component")]
    public Rigidbody2D rb;

    [Header("Speed")]
    [Tooltip("The vertical speed")]
    public float vSpeed = 1.0f;
    [Tooltip("The horizontal spped")]
    public float hSpeed = 1.0f;

    public string lastButton = "up";
    
    public enum rotationStates {noRotation, Degrees_90, Degree_45, Smooth};
    [Header("Rotation")]
    [Tooltip("The types of rotation, the smooth rotations state the game object to rotate to the respective" +
        " point")]
    public rotationStates rotationState;
    [Tooltip("Only useful dealing with the smooth rotation state, allow for quicker rotation to a position")]
    public float rotationspeed = 1.0f;

    
    //HealthScript healthScript;
    //private AnimationScript animScript;

    // Start is called before the first frame update
    void Start()
    {
        //animScript = GetComponent<AnimationScript>();
        //healthScript = GetComponent<HealthScript>();
        DefaultButtons();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if(CheckInput())
        {
            animtionFunction();
            movement();
            rotationFunction();
        }
    }

    public void movement()
    {

            if (Input.GetKey(LeftButton))
            {
                rb.velocity = new Vector2(-hSpeed, rb.velocity.y);
            lastButton = "left";
            }
            else if (Input.GetKey(RightButton))
            {
                rb.velocity = new Vector2(hSpeed, rb.velocity.y);
                lastButton = "right";
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }

            if (Input.GetKey(UpButton))
            {
                rb.velocity = new Vector2(rb.velocity.x, vSpeed);
                lastButton = "up";
            }
            else if (Input.GetKey(DownButton))
            {
                rb.velocity = new Vector2(rb.velocity.x, -vSpeed);
                lastButton = "down";
            }
            else {

                rb.velocity = new Vector2(rb.velocity.x, 0);

            if(rb.velocity.x == 0f && rb.velocity.y == 0f )
                lastButton = "none";

        }
        

    }

    public void rotationFunction()
    {   
        if (rotationState != rotationStates.noRotation)
        {
            if (Input.GetKey(LeftButton))
            {
                if (rotationState == rotationStates.Smooth)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 90), rotationspeed);
                    
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 0, 90);
                }
            }

            if (Input.GetKey(RightButton))
            {
                if (rotationState == rotationStates.Smooth)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 270), rotationspeed);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 0, 270);
                }
            }

            if (Input.GetKey(UpButton))
            {
                if (rotationState == rotationStates.Smooth)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0), rotationspeed);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }

            if (Input.GetKey(DownButton))
            {  if (rotationState == rotationStates.Smooth)
                {
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 180), rotationspeed);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 0, 180);
                }
            }

            if(rotationState == rotationStates.Degree_45 || rotationState == rotationStates.Smooth)
            {
                if(Input.GetKey(RightButton) && Input.GetKey(UpButton))
                {
                    if(rotationState == rotationStates.Smooth)
                    {
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 315), rotationspeed);
                    }
                    else
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 315);
                    }
                }

                if (Input.GetKey(RightButton) && Input.GetKey(DownButton))
                {
                    if (rotationState == rotationStates.Smooth)
                    {
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 225), rotationspeed);
                    }
                    else
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 225);
                    }
                }

                if (Input.GetKey(LeftButton) && Input.GetKey(UpButton))
                {
                    if (rotationState == rotationStates.Smooth)
                    {
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 45), rotationspeed);
                    }
                    else
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 45);
                    }
                }

                if (Input.GetKey(LeftButton) && Input.GetKey(DownButton))
                {
                    if (rotationState == rotationStates.Smooth)
                    {
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 135), rotationspeed);
                    }
                    else
                    {
                        transform.rotation = Quaternion.Euler(0, 0, 135);
                    }
                }

            }
        }
        
    }

    public void DefaultButtons()
    {
        if (LeftButton == "")
        {
            LeftButton = "left";
        }

        if (RightButton == "")
        {
            RightButton = "right";
        }

        if (UpButton == "")
        {
            UpButton = "up";
        }

        if (DownButton == "")
        {
            DownButton = "down";
        }


    }
    public bool CheckInput()
    {

        /*if (healthScript != null)
        {
            if (healthScript.dead|| healthScript.noInputCurrently)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return true;
        }*/
        return true;
    }

    public void animtionFunction()
    {
        /*if(animScript)
        {
            if(Input.GetKey(LeftButton)|| Input.GetKey(DownButton)|| Input.GetKey(RightButton)||Input.GetKey(UpButton))
            {
                animScript.moving = true;
            }
            else
            {
                animScript.moving = false;
            }
        }*/
    }
}
