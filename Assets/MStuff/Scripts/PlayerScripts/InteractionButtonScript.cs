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

    
    private void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            wepn.useWeapon(this.gameObject);
        }
    }
}
