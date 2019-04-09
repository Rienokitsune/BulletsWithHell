using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class InventorySlot : MonoBehaviour,IDropHandler,IDragHandler
{
   

    public void OnDrop(PointerEventData eventData)
    {

        Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);
        if(transform.childCount == 0 && eventData.pointerDrag.GetComponent<WeaponDraggableUI>())
        {
            eventData.pointerDrag.transform.position = this.transform.position;
            eventData.pointerDrag.transform.SetParent(transform);

        }
        else if(transform.childCount == 1 && eventData.pointerDrag.GetComponent<WeaponDraggableUI>())
        {
            
            Transform item = transform.GetChild(0);
            item.SetParent(eventData.pointerDrag.GetComponent<WeaponDraggableUI>().GetLastPos());
            item.position = eventData.pointerDrag.GetComponent<WeaponDraggableUI>().GetLastPos().position;
            eventData.pointerDrag.transform.position = this.transform.position;
            eventData.pointerDrag.transform.SetParent(transform);
           
        }
            
            
    }
    public void OnDrag(PointerEventData eventData)
    {
        
    }

    
}
