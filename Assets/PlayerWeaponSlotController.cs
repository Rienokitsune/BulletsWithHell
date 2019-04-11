using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponSlotController : MonoBehaviour
{
    [SerializeField] PlayerData data;
    [SerializeField] GameObject[] weaponSlots;
    int activeSlots;
    float slotRotationAngle;
    void Start()
    {
        ReloadWeapons();        
    }

    public void ReloadWeapons()
    {
        activeSlots = data.slots.Count;
        slotRotationAngle = 360 / activeSlots;
        for (int i = 0; i < activeSlots; i++)
        {
            weaponSlots[i].SetActive(true);
           // Destroy(weaponSlots[i].transform.GetChild(0));
            GameObject obj = Instantiate(data.slots[i].WeaponPrefab, weaponSlots[i].transform);
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
