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
    public float waitTimeCounter = 0.0f;
    private void Update()
    {
        if(Input.GetKeyDown("space")&&ready)
        {
            wepn.useWeapon(this.gameObject);
            waitTimeCounter = 0.0f;
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
}
