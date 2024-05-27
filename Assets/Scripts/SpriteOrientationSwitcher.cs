using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteOrientationSwitcher : MonoBehaviour
{
    public TopDownMovement movementController;
    public string lastdirection;
    public SpriteRenderer sprite_Up;
    public SpriteRenderer sprite_Down;
    public SpriteRenderer sprite_Left;
    public SpriteRenderer sprite_Right;

    // Update is called once per frame
    void Update()
    {
        UpdateSpriteOrientation();
    }

    public void UpdateSpriteOrientation()
    {

        if (movementController.lastButton == "left" && sprite_Left.enabled == false) {
            sprite_Left.enabled = true;
            sprite_Right.enabled = false;
            sprite_Up.enabled = false;
            sprite_Down.enabled = false;

            return;

        }

        if (movementController.lastButton == "right" && sprite_Right.enabled == false)
        {
            sprite_Left.enabled = false;
            sprite_Right.enabled = true;
            sprite_Up.enabled = false;
            sprite_Down.enabled = false;

            return;

        }

        if (movementController.lastButton == "up" && sprite_Up.enabled == false)
        {
            sprite_Left.enabled = false;
            sprite_Right.enabled = false;
            sprite_Up.enabled = true;
            sprite_Down.enabled = false;

            return;

        }

        if (movementController.lastButton == "down" && sprite_Down.enabled == false)
        {
            sprite_Left.enabled = false;
            sprite_Right.enabled = false;
            sprite_Up.enabled = false;
            sprite_Down.enabled = true;

            return;

        }

    }
}
