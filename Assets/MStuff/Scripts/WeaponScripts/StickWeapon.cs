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
    private Quaternion rot;
    public override void useWeapon(GameObject parent)
    {
        Transform spawnPos;
        movement = parent.GetComponent<TopDownMovement>();
        interaction = parent.GetComponent<InteractionButtonScript>();
        
        switch(movement.lastButton)
        {
            case "up":
                spawnPos = interaction.up;
                Debug.Log("upppp");
                rot = Quaternion.Euler(0, 0,90);
                dir = "up";

                break;
            case "down":
                spawnPos = interaction.down;
                Debug.Log("dowwn");
                dir = "down";
                rot = Quaternion.Euler(0, 0, 90);
                break;
            case "left":
                spawnPos = interaction.left;
                rot = Quaternion.Euler(0, 0, 0);
                dir = "left";
                break; 
            case "right":
                spawnPos = interaction.right;
                rot = Quaternion.Euler(0, 0, 0);
                dir = "right";
                break;
            default: 
                spawnPos = interaction.right; 
                dir = "right";
                break;
        }

        if(ready)
        {
            GameObject bull = Instantiate(hitBox, spawnPos.position, rot) as GameObject;
            int addp = parent.GetComponent<InteractionButtonScript>().additionalPower;
            bull.GetComponent<ProjectileScript>().attack = power + addp;
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
