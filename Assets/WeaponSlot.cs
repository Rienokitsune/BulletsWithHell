using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeaponSlot : MonoBehaviour,IDropHandler
{

    [SerializeField] WeaponType type;
    [SerializeField] Image weaponSprite;

    public void OnDrop(PointerEventData eventData)
    {
        type = eventData.pointerDrag.GetComponent<WeaponDraggableUI>().GetWeaponType();
        weaponSprite.sprite = type.WeaponSprite;
    }

   
      
}
