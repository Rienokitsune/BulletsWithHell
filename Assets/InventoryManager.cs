using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryManager : MonoBehaviour,IDropHandler, IPointerExitHandler
{

    public GameObject slotPrefab;
    public Transform slotHolder;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.GetComponent<WeaponDraggableUI>())
        {
            GameObject slot = Instantiate(slotPrefab, slotHolder);
            slot.transform.SetParent(slotHolder);
            slot.transform.SetAsFirstSibling();

            eventData.pointerDrag.transform.SetParent(slot.transform);
            eventData.pointerDrag.transform.position = slot.transform.position;
        }
        Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);
         
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    void Start()
    {
        
    }

    public Transform createNewSlot()
    {
        GameObject slot = Instantiate(slotPrefab, slotHolder);
        slot.transform.SetParent(slotHolder);
        slot.transform.SetAsFirstSibling();
        return slot.transform;
    }

}
