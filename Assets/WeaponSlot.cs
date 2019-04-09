using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponSlot : MonoBehaviour,IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            eventData.pointerDrag.transform.position = this.transform.position;
            eventData.pointerDrag.transform.SetParent(transform);

        }
        else
        {
            Transform item = transform.GetChild(0);
            item.SetParent(eventData.pointerDrag.GetComponent<WeaponDraggableUI>().GetLastPos());
            item.position = eventData.pointerDrag.GetComponent<WeaponDraggableUI>().GetLastPos().position;
            eventData.pointerDrag.transform.position = this.transform.position;
            eventData.pointerDrag.transform.SetParent(transform);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
