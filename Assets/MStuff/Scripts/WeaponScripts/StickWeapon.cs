using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class StickWeapon : WeaponLoadout
{
    public bool ready = true;
    public GameObject hitBox;
    public TopDownMovement movement;    
    public InteractionButtonScript interaction;
    private string dir;
    public override void useWeapon(GameObject parent)
    {
        Transform spawnPos;
        movement = parent.GetComponent<TopDownMovement>();
        interaction = parent.GetComponent<InteractionButtonScript>();
        
        switch(movement.lastButton)
        {
            case "up":
                spawnPos = interaction.up;
                dir = "up";
                break;
            case "down":
                spawnPos = interaction.down;
                dir = "down";
                break;
            case "left":
                spawnPos = interaction.left;
                dir = "left";
                break; 
            case "right":
                spawnPos = interaction.right;
                dir = "right";
                break;
            default: 
                spawnPos = interaction.right; 
                dir = "right";
                break;
        }

        if(ready)
        {
            Instantiate(hitBox, spawnPos.position, Quaternion.identity);
            ready = false;
            //StartCoroutine(reset());
            reset();
        }
    }

    public void reset()
    {
        //int i = 0; 
        //yield return new WaitForSeconds(1.0);
        //
        ready = true;
    }
}
