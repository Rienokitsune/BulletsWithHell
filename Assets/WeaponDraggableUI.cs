using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using UnityEngine.UI;

public class WeaponDraggableUI : MonoBehaviour, IBeginDragHandler,IEndDragHandler,IDragHandler
{

    [SerializeField] Transform dragLayer;
    [SerializeField] WeaponType type;
    private Transform startPos;
    public bool InWeaponSlot = false;
    public CanvasGroup group;

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
        GoToLastPos();
        group.blocksRaycasts = true;
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

    public WeaponType GetWeaponType()
    {
        return type;
    }

}
