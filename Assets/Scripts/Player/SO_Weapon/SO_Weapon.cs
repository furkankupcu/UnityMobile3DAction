using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Weapon", order = 51)]
public class SO_Weapon : SO_Item { 

    public int damage;
    public float fireRate;
    public int range;
    public GameObject muzzle;
}
