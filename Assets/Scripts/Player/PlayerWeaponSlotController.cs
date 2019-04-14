using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponSlotController : MonoBehaviour
{
    [SerializeField] PlayerLoadout loadout;
    [SerializeField] GameObject[] weaponSlots;
    int activeSlots;
    float slotRotationAngle;
    void Start()
    {
        ReloadWeapons();        
    }

    public void ReloadWeapons()
    {

        activeSlots = PlayerData._PlayerData.GetLevel(UpgradeTypes.UpgradeType.BulletNum);
        slotRotationAngle = 360 / activeSlots;
        for (int i = 0; i <= activeSlots-1; i++)
        {
            weaponSlots[i].SetActive(true);
            GameObject obj = Instantiate(loadout.GetWeaponType(loadout.currentLoadout[i]).WeaponPrefab, weaponSlots[i].transform);
            obj.transform.Rotate(new Vector3(0, 0, slotRotationAngle * i));
        }
    }
    public void ClearWeapons()
    {
        foreach  (GameObject slot in weaponSlots)
        {
            if(slot.transform.childCount != 0)
            {
                foreach(Transform child in slot.transform)
                {
                    child.GetComponent<PlayerWeapon>().DestroyWeapon();
                }
                
            }
            
            
        }
    }
}
