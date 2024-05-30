using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractionButtonScript : MonoBehaviour
{
    
    public WeaponLoadout wepn;
    public Transform up;
    public Transform down;
    public Transform left;
    public Transform right;

    public int additionalPower = 0;

    public bool ready = true;
    public AudioSource audioC;
    public float waitTimeCounter = 100.0f;
    public float rate = 1.0f;
    void Start()
    {
        audioC = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if(Input.GetKeyDown("space")&&ready)
        {
            if(waitTimeCounter > wepn.takeAway)
            {
                wepn.useWeapon(this.gameObject);
                waitTimeCounter -= wepn.takeAway;
                playSound();
            }
            //ready = false;
        }

        if(waitTimeCounter <= 0.0f)
        {
            waitTimeCounter = 0.0f;
            //ready=false;
        }

        //if(!ready)
        //{
            waitTimeCounter += Time.deltaTime*rate;
            if(waitTimeCounter >= 100.0)
            {
                ready = true;
            }
        //}
    }

    public void playSound()
    {
        audioC.clip = wepn.sound;
        audioC.Play();
    }
}
