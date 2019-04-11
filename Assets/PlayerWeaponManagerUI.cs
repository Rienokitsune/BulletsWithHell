using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManagerUI : MonoBehaviour,ILoadData
{
    [SerializeField] PlayerData data;
    [SerializeField] WeaponSlot[] slots;
    [SerializeField] List<WeaponType> equipped;
    int activeSlots;
    float slotRotationAngle;
    void Start()
    {
        activeSlots = data.GetLevel(UpgradeTypes.UpgradeType.BulletNum);
        slotRotationAngle = 360 / activeSlots;
        for (int i = 0; i < activeSlots; i++)
        {
           slots[i].gameObject.SetActive(true);           
        }

        Load();

    }

    public void ReloadEquipped()
    {
        equipped = new List<WeaponType>();
        foreach (WeaponSlot slot in slots)
        {
            if (slot.GetWeapon())
            {
                equipped.Add(slot.GetWeapon());
            }
            
        }

        data.slots = equipped;
        data.Save();
    }

    public void Load()
    {
        for (int i = 0; i <= data.slots.Count-1; i++)
        {
            slots[i].SetWeapon(data.slots[i]);
        }
    }

}
