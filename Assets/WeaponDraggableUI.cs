using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using UnityEngine.UI;

public class WeaponDraggableUI : MonoBehaviour, IBeginDragHandler,IEndDragHandler,IDragHandler
{

    [SerializeField] Transform dragLayer;
    public List<GameObject> hovering;
    private Transform startPos;
    private CanvasGroup group;
    void Start()
    {
        group = GetComponent<CanvasGroup>();
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        startPos = gameObject.transform.parent.transform;
        group.blocksRaycasts = false;
        this.transform.SetParent(dragLayer);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(eventData.hovered.Count == 0) { GoToLastPos(); }
        group.blocksRaycasts = true;
        if (startPos.gameObject.GetComponent<InventorySlot>() && !eventData.pointerEnter.gameObject.GetComponent<WeaponDraggableUI>())
        {

            startPos.gameObject.SetActive(false);
        }
    }

    public Transform GetLastPos()
    {
        return startPos;
    }

    public void GoToLastPos()
    {
        transform.position = startPos.position;
        transform.SetParent(startPos);
    }

}
