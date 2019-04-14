using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
[CreateAssetMenu]
public class PlayerLoadout : ScriptableObject, ISaveData,ILoadData
{
    public static PlayerLoadout _Loadout;
    PlayerWeaponList weaponList;
    public enum WeaponTypes
    {
        square,
        triangle,
        pentagon,
        hexagon
    }

    [SerializeField]public WeaponTypes[] currentLoadout;

    public GameObject GetWeapon(WeaponTypes type)
    {
        foreach(WeaponType weapon in weaponList.Types)
        {
            Debug.Log(type);
            if (weapon.type == type)
            {
            GameObject weaponType = weapon.WeaponPrefab;
            return weaponType;
            }
        }

        return GetWeapon(WeaponTypes.triangle);
    }

    public WeaponType GetWeaponType(WeaponTypes type)
    {
        foreach (WeaponType weapon in weaponList.Types)
        {
            Debug.Log(type);
            if (weapon.type == type)
            { 
                return weapon;
            }
        }

        return GetWeaponType(WeaponTypes.triangle);
    }

    private void OnEnable()
    {
        _Loadout = this;
    }
    
    [Button]
    public void Save()
    {

        ES3.Save<PlayerLoadout>("PlayerLoadout", this, "SaveData");
        foreach(WeaponTypes type in currentLoadout)
        {
            Debug.Log(GetWeapon(type) + " weapon in loadout Saved");
        }
    }

    [Button]
    public void Load()
    {
        if (ES3.FileExists("SaveData"))
        {
            if (ES3.KeyExists("PlayerLoadout", "SaveData"))
            {
                ES3.LoadInto<PlayerLoadout>("PlayerLoadout", "SaveData", this);
            }
            else
            {
                WeaponTypes[] types = new WeaponTypes[5];

                for (int i = 0; i <= 4; i++)
                {
                        types[i] = WeaponTypes.triangle;
                }
                currentLoadout = types;
                Debug.Log("Initialized Player Loadout");
                ES3.Save<PlayerLoadout>("PlayerLoadout", this, "SaveData");
                Debug.Log("SaveData File Not found, PlayerLoadout key created and loaded default values");
                return;
            }

            weaponList = PlayerWeaponList._List;      

        }
        else
        {

            Debug.LogError("SaveDataNotFound PlayerLoadout LoadFailed");
            return;
        }
        
    }
}
