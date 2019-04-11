using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class WeaponSlot : MonoBehaviour,IDropHandler
{
    [SerializeField] UnityEvent weaponChanged;
    [SerializeField] WeaponType type;
    [SerializeField] Image weaponSprite;

    public void OnDrop(PointerEventData eventData)
    {
        
        type = eventData.pointerDrag.GetComponent<WeaponDraggableUI>().GetWeaponType();
        weaponSprite.color = eventData.pointerDrag.GetComponent<Image>().color;
        weaponSprite.sprite = type.WeaponSprite;
        weaponChanged.Invoke();
    }

   public WeaponType GetWeapon()
    {
        return type;
    }

    public void SetWeapon(WeaponType type)
    {
        this.type = type;
        weaponSprite.sprite = type.WeaponSprite;
    }
      
}
