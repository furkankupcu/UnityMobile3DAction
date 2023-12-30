using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Weapon", order = 51)]
public class SO_Weapon : ScriptableObject
{
    public string weaponName;
    public int damage;
    public float fireRate;
    public int range;
}
