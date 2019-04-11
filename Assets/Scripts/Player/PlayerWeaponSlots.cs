using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponSlots : ScriptableObject, ISaveData, ILoadData
{
    [SerializeField]public WeaponType[] weaponSlots;

    public void Save()
    {
        
    }

    public void Load()
    {
        
    }



}
