using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DroppedItemOnSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject aDraggedItem = eventData.pointerDrag;
        DragScript aDroppedItem = aDraggedItem.GetComponent<DragScript>();
        aDroppedItem.lastParent = transform;
    }
}
