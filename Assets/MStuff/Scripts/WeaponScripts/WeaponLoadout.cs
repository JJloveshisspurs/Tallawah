using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Weapon", menuName = "WeaponObject", order = 1)]
public class WeaponLoadout : ScriptableObject
{
    public Animator anim;
    public bool limitUse = false;
    public int ammo = 0;
    public Sprite image;
    public int power = 1;

    public float coolDown = 1.0f;
    public virtual void useWeapon(GameObject parent)
    {

    }



}
