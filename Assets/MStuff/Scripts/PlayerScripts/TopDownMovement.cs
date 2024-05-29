using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private SpriteRenderer sr;

    [Header("Input")]
    [Tooltip("Input any key to move the gameObject left. If left empty, it will automatically pick the left arrow key")]
    public string LeftButton;
    [Tooltip("Input any key to move the gameObject right. If left empty, it will automatically pick the right arrow key")]
    public string RightButton;
    [Tooltip("Input any key to move the gameObject up. If left empty, it will automatically pick the up arrow key")]
    public string UpButton;
    [Tooltip("Input any key to move the gameObject down. If left empty, it will automatically pick the down arrow key")]
    public string DownButton;

    [Header("Components")]
    [Tooltip("This script needs a Rigidbody2D to work, it will automatically get it if on the component")]
    public Rigidbody2D rb;

    [Header("Speed")]
    [Tooltip("The vertical speed")]
    public float vSpeed = 1.0f;
    [Tooltip("The horizontal speed")]
    public float hSpeed = 1.0f;

    public string lastButton = "up";

    public enum RotationStates { NoRotation, Degrees90, Degrees45, Smooth };
    [Header("Rotation")]
    [Tooltip("The types of rotation. The smooth rotation state makes the game object rotate to the respective point smoothly")]
    public RotationStates rotationState;
    [Tooltip("Only useful when dealing with the smooth rotation state, allows for quicker rotation to a position")]
    public float rotationSpeed = 1.0f;

    // HealthScript healthScript;
    // private AnimationScript animScript;

    void Start()
    {
        // animScript = GetComponent<AnimationScript>();
        // healthScript = GetComponent<HealthScript>();
        DefaultButtons();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (CheckInput())
        {
            AnimationFunction();
            Movement();
            RotationFunction();
        }
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-hSpeed, rb.velocity.y);
            lastButton = "left";
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(hSpeed, rb.velocity.y);
            lastButton = "right";
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, vSpeed);
            lastButton = "up";
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, -vSpeed);
            lastButton = "down";
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);

            if (rb.velocity.x == 0f && rb.velocity.y == 0f)
            {
                lastButton = "none";
            }
        }
    }

    private void RotationFunction()
    {
        if (rotationState != RotationStates.NoRotation)
        {
            CheckRotation(LeftButton, 90);
            CheckRotation(RightButton, 270);
            CheckRotation(UpButton, 0);
            CheckRotation(DownButton, 180);

            if (rotationState == RotationStates.Degrees45 || rotationState == RotationStates.Smooth)
            {
                CheckDiagonalRotation(RightButton, UpButton, 315);
                CheckDiagonalRotation(RightButton, DownButton, 225);
                CheckDiagonalRotation(LeftButton, UpButton, 45);
                CheckDiagonalRotation(LeftButton, DownButton, 135);
            }
        }
    }

    private void CheckRotation(string direction, float angle)
    {
        if (Input.GetKey(direction))
        {
            if (rotationState == RotationStates.Smooth)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, angle), rotationSpeed);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
    }

    private void CheckDiagonalRotation(string direction1, string direction2, float angle)
    {
        if (Input.GetKey(direction1) && Input.GetKey(direction2))
        {
            if (rotationState == RotationStates.Smooth)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, angle), rotationSpeed);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
    }

    private void DefaultButtons()
    {
        if (string.IsNullOrEmpty(LeftButton))
        {
            LeftButton = "left";
        }

        if (string.IsNullOrEmpty(RightButton))
        {
            RightButton = "right";
        }

        if (string.IsNullOrEmpty(UpButton))
        {
            UpButton = "up";
        }

        if (string.IsNullOrEmpty(DownButton))
        {
            DownButton = "down";
        }
    }

    private bool CheckInput()
    {
        /*if (healthScript != null)
        {
            if (healthScript.dead || healthScript.noInputCurrently)
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

    private void AnimationFunction()
    {
        /*if (animScript)
        {
            if (Input.GetKey(LeftButton) || Input.GetKey(DownButton) || Input.GetKey(RightButton) || Input.GetKey(UpButton))
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
