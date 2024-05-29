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
    public float waitTimeCounter = 0.0f;

    void Start()
    {
        audioC = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if(Input.GetKeyDown("space")&&ready)
        {
            wepn.useWeapon(this.gameObject);
            waitTimeCounter = 0.0f;
            playSound();
            ready = false;
        }

        if(!ready)
        {
            waitTimeCounter += Time.deltaTime;
            if(waitTimeCounter >= wepn.coolDown)
            {
                ready = true;
            }
        }
    }

    public void playSound()
    {
        audioC.clip = wepn.sound;
        audioC.Play();
    }
}
