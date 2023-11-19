using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DroppedItemOnSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject aDraggedItem = eventData.pointerDrag;
            DragScript aDroppedItem = aDraggedItem.GetComponent<DragScript>();
            aDroppedItem.lastParent = transform;
        }
    }
}
