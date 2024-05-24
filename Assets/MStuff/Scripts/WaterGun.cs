using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WaterGun : WeaponLoadout
{
    public TopDownMovement movement;    
    public InteractionButtonScript interaction;
    public GameObject bullet;
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

        GameObject bull = Instantiate(bullet, spawnPos.position, Quaternion.identity) as GameObject;
        bull.GetComponent<ProjectileScript>().dir = dir;
        int addp = parent.GetComponent<InteractionButtonScript>().additionalPower;
        bull.GetComponent<ProjectileScript>().attack = power + addp;
    }
}
