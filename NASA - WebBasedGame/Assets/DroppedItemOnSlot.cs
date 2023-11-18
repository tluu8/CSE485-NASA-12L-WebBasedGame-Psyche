using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DroppedItemOnSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        { 
        GameObject aDroppedItem = eventData.pointerDrag;
        DragScript draggedItem = aDroppedItem.GetComponent<DragScript>();
        draggedItem.lastParent = transform;
        }
    }
}
