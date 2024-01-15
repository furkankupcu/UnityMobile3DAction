using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{

    [SerializeField] private SO_Weapon[] lowLevelWeapons;
    [SerializeField] private SO_Weapon[] midLevelWeapons;
    [SerializeField] private SO_Weapon[] highLevelWeapons;
    [SerializeField] private SO_Weapon[] epicLevelWeapons;

    private SO_Weapon selectedWeapon;
    int _randomLevel;

    private void Update()
    {
        Debug.Log("Spawn");
    }

    private void Start()
    {
        GetRandomWeapon();
    }

    public SO_Weapon GetRandomWeapon()
    {
        _randomLevel = Random.Range(0, 3);

        switch (_randomLevel)
        {
            case 0:
                selectedWeapon = midLevelWeapons[SelectNumberWithArraySize(midLevelWeapons)];
                break;
            case 1:
                selectedWeapon = highLevelWeapons[SelectNumberWithArraySize(highLevelWeapons)];
                break;
            case 2:
                selectedWeapon = epicLevelWeapons[SelectNumberWithArraySize(epicLevelWeapons)];
                break;
            default:
                selectedWeapon = lowLevelWeapons[SelectNumberWithArraySize(lowLevelWeapons)];
                break;
        }

        return selectedWeapon;
    }

    public void SpawnObject()
    {
        var gameObj = Instantiate(GetRandomWeapon());
    }

    private void GetUniqueId()
    {
       //Get Database
    }

    private int SelectNumberWithArraySize(SO_Weapon[] arr)
    {
        return Random.Range(0, arr.Length - 1);
    }
}
