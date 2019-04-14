using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManagerUI : MonoBehaviour,ILoadData
{
    [SerializeField] WeaponType defaultWeapon;
    [SerializeField] PlayerData data;
    [SerializeField] PlayerLoadout loadout;
    [SerializeField] WeaponSlot[] slots;
    [SerializeField] List<PlayerLoadout.WeaponTypes> equipped;
    int activeSlots;

    void Start()
    {
        LoadSlots();

        Load();

    }

    public void LoadSlots()
    {
        activeSlots = data.GetLevel(UpgradeTypes.UpgradeType.BulletNum);

        for (int i = 0; i < activeSlots; i++)
        {
            slots[i].gameObject.SetActive(true);
            slots[i].SetWeapon(PlayerLoadout.WeaponTypes.triangle);
        }
    }

    public void ReloadEquipped()
    {
        equipped = new List<PlayerLoadout.WeaponTypes>();

        foreach (WeaponSlot slot in slots)
        {      
                equipped.Add(slot.GetWeaponType());
        }

        loadout.currentLoadout = equipped.ToArray();
        loadout.Save();
    }

    public void Load()
    {
        for (int i = 0; i <= loadout.currentLoadout.Length-1; i++)
        {
            slots[i].SetWeapon(loadout.currentLoadout[i]);
        }
    }

}
