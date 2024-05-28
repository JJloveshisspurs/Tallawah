using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteOrientationSwitcher : MonoBehaviour
{
    public TopDownMovement movementController;
    public string lastdirection;
    public SpriteRenderer sprite_Up;
    public SpriteAnimator up_animation;

    public SpriteRenderer sprite_Down;
    public SpriteAnimator down_animation;


    public SpriteRenderer sprite_Left;
    public SpriteAnimator left_animation;

    public SpriteRenderer sprite_Right;
    public SpriteAnimator right_animation;

    public SpriteRenderer mainPlayerSprite;

    public void Start()
    {
        mainPlayerSprite.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSpriteOrientation();
    }

    public void UpdateSpriteOrientation()
    {
        lastdirection = movementController.lastButton;
        

        if (movementController.lastButton == "left" ) {
            sprite_Left.enabled = true;
            left_animation.StartAnimating();
            sprite_Right.enabled = false;
            sprite_Up.enabled = false;
            sprite_Down.enabled = false;

           

        }else if (movementController.lastButton == "right" )
        {
            sprite_Left.enabled = false;
            sprite_Right.enabled = true;
            right_animation.StartAnimating();
            sprite_Up.enabled = false;
            sprite_Down.enabled = false;

            

        }else if (movementController.lastButton == "up" )
        {
            sprite_Left.enabled = false;
            sprite_Right.enabled = false;
            sprite_Up.enabled = true;
            up_animation.StartAnimating();
            sprite_Down.enabled = false;

           

        }else if (movementController.lastButton == "down" )
        {
            sprite_Left.enabled = false;
            sprite_Right.enabled = false;
            sprite_Up.enabled = false;
            sprite_Down.enabled = true;
            down_animation.StartAnimating();
           

        }else if (movementController.lastButton == "none")
        {
            left_animation.StopAnimating();
            right_animation.StopAnimating();
            up_animation.StopAnimating();
            down_animation.StopAnimating();
            sprite_Left.enabled = false;
            sprite_Right.enabled = false;
            sprite_Up.enabled = false;
            sprite_Down.enabled = true;
            

        }

    }
}
