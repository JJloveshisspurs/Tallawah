using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public int keys = 0;
    public WeaponLoadout[] loadout;
    public int pos = 0;
    public int maxpos = 1;

    public InteractionButtonScript inter;
    // Start is called before the first frame update
    void Start()
    {
        inter = GetComponent<InteractionButtonScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("c"))
        {
            pos++;
            if(pos >= maxpos)
            {
                pos = 0;
            }
            inter.wepn = loadout[pos];
        }
    }

    public void GetWepnFunction()
    {
        maxpos++;
    }
}
