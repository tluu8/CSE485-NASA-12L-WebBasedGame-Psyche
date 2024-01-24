using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEditor.Overlays;

public class DragScript : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    // The item's sprite
    public Image anImage;

    // The item's display name and description when hovered over
    public GameObject textItemPrefab;
    public GameObject descItemPrefab;

    // ** Helper variables to aid in calculation **
    // overallCanvas = Self explanatory, background canvas of everything
    // lastParent = The last slot that the item was in
    // newTitle = A new title to be attached to the item
    // newDescription = A new description to be attached to the item

    [HideInInspector] public Transform overallCanvas;
    [HideInInspector] public Transform lastParent;
    [HideInInspector] public GameObject newTitle;
    [HideInInspector] public GameObject newDescription;

    // The current inventory being used
    private InventorySystem aSystem;

    void Start()
    {
        // Finding the inventory currently in use
        aSystem = FindObjectOfType<InventorySystem>();
        if (aSystem == null)
        {
            Debug.LogError("Inventory system not found in the scene!");
        }
    }

    // When beginning to drag an item, event handler is called which
    // makes the image be above everything else,
    // makes the item's icon not interfere with the drop,
    // and records the last slot it was successfully placed in
    public void OnBeginDrag(PointerEventData eventData)
    {
        lastParent = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        anImage.raycastTarget = false;
    }

    // Event handler to move item to follow cursor when dragging item
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    // When completing a drag, the event handler finds a slot to drop in
    // and re-enables the raycasting of the image
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(lastParent);
        anImage.raycastTarget = true;
    }

    // The event handler logic for when an icon is hovered over
    public void OnPointerEnter(PointerEventData eventData)
    {
        overallCanvas = transform.parent.transform.parent.transform.parent;
        newTitle = Instantiate(textItemPrefab, overallCanvas);
        newTitle.transform.position.Set(670, 330, 0);
        TextMeshProUGUI textPortion = newTitle.GetComponent<TextMeshProUGUI>();
        textPortion.text = transform.name;
        newTitle.SetActive(true);


        newDescription = Instantiate(descItemPrefab, overallCanvas);
        TextMeshProUGUI textDescPortion = newDescription.GetComponent<TextMeshProUGUI>();
        textDescPortion.text = aSystem.descriptions[transform.name];
        newDescription.SetActive(true);

    }

    // The event handler logic for when an icon is finished hovering over
    public void OnPointerExit(PointerEventData eventData)
    {
        newTitle.SetActive(false);
        newDescription.SetActive(false);
        Destroy(newTitle.gameObject);
        Destroy(newDescription.gameObject);
    }
}
