using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.VirtualTexturing;

public class DroppedItemOnSlot : MonoBehaviour, IDropHandler
{
    private InventorySystem aSystem;
    public GameObject itemPrefab;

    void Start()
    {
        aSystem = FindObjectOfType<InventorySystem>();
        if (aSystem == null)
        {
            Debug.LogError("Inventory system not found in the scene!");
        }
    }

    void Update()
    {
        aSystem = FindObjectOfType<InventorySystem>();
        if (aSystem == null)
        {
            Debug.LogError("Inventory system not found in the scene!");
        }
    }

    public bool combinable(GameObject firstItemToCheck, GameObject secondItemToCheck)
    {
        if (aSystem.combinableItems[firstItemToCheck.name] == secondItemToCheck.name)
        {
            return true;
        }
        else if (aSystem.combinableItems[secondItemToCheck.name] == firstItemToCheck.name)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject aDraggedItem = eventData.pointerDrag;
        DragScript aDroppedItem = aDraggedItem.GetComponent<DragScript>();
        if (transform.childCount == 0)
        {
            aDroppedItem.lastParent = transform;
        }
        else if (combinable(transform.GetChild(0).gameObject, aDraggedItem.gameObject))
        {
            DragScript theOriginalItem = transform.GetChild(0).GetComponent<DragScript>();
            aDroppedItem.lastParent = transform;
            foreach (GameObject item in aSystem.items)
            {
                if (item.name == theOriginalItem.name)
                {
                    aSystem.items.Remove(item);
                    break;
                }
            }
            foreach (GameObject item in aSystem.items)
            {
                if (item.name == aDraggedItem.name)
                {
                    aSystem.items.Remove(item);
                    break;
                }
            }
            //aSystem.items.Remove(aDraggedItem.gameObject);
            //aSystem.items.Remove(transform.GetChild(0).gameObject);
            //Destroy(aDroppedItem.gameObject);
            theOriginalItem.newTitle.SetActive(false);
            theOriginalItem.newDescription.SetActive(false);
            Destroy(theOriginalItem.newTitle.gameObject);
            Destroy(theOriginalItem.newDescription.gameObject);
            Destroy(aDroppedItem.newTitle.gameObject);
            Destroy(aDroppedItem.newDescription.gameObject);
            Destroy(aDraggedItem.gameObject);
            Destroy(transform.GetChild(0).gameObject);
            GameObject newItem = Instantiate(itemPrefab, transform);
            newItem.name = "TestItem4";
            newItem.transform.name = "TestItem4";
            aSystem.AddItem(newItem);


        }
    }
}
