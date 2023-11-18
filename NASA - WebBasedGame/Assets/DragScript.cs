using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragScript : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Image anImage;
    [HideInInspector] public Transform lastParent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        lastParent = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        anImage.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(lastParent);
        anImage.raycastTarget = true;
    }
}
