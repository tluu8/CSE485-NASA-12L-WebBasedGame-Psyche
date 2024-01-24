using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.VirtualTexturing;

public class DroppedItemOnSlot : MonoBehaviour, IDropHandler
{
    // The inventory being used
    private InventorySystem aSystem;

    // The current prefab or template to generate new items. Mainly used for testing purposes,
    // needs to be replaced with a system that allows for different kinds of items
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

    // The function to check whether the item being held and the item in the slot are combinable or not
    // If they are, they are marked for the combination process
    // If they aren't, then the dragged item returns to its original slot
    public bool combinable(GameObject firstItemToCheck, GameObject secondItemToCheck)
    {
        // Checking whether the items' names are in the dictionaries of either item, no matter the order
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

    // The event handler for when an item gets dropped
    public void OnDrop(PointerEventData eventData)
    {
        GameObject aDraggedItem = eventData.pointerDrag;
        DragScript aDroppedItem = aDraggedItem.GetComponent<DragScript>();
        
        // If the inventory slot is empty, it is marked to allow the drop 
        if (transform.childCount == 0)
        {
            aDroppedItem.lastParent = transform;
        }

        // If the inventory slot isn't empty but the item found in the slot is combinable
        // with the currently being held item in the mouse pointer, then the combination
        // process will take effect, deleting both of the items and replacing the item
        // being dropped with a new item
        else if (combinable(transform.GetChild(0).gameObject, aDraggedItem.gameObject))
        {
            // i.e. The item in the slot
            DragScript theOriginalItem = transform.GetChild(0).GetComponent<DragScript>();

            // The item being held by the cursor is marked to drop in the slot
            aDroppedItem.lastParent = transform;

            // Removing each of the parents (two combinable items) from the backend inventory list
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

            // Removing the combined items's displayed name and description
            theOriginalItem.newTitle.SetActive(false);
            theOriginalItem.newDescription.SetActive(false);
            Destroy(theOriginalItem.newTitle.gameObject);
            Destroy(theOriginalItem.newDescription.gameObject);
            Destroy(aDroppedItem.newTitle.gameObject);
            Destroy(aDroppedItem.newDescription.gameObject);

            // Deleting both of the old inventory items
            Destroy(aDraggedItem.gameObject);
            Destroy(transform.GetChild(0).gameObject);

            // Creating a new combined item.
            // NOTE: This is just for testing; needs to be altered to accomodate rest of game
            //       i.e. Needs change in creation of object to allow different objects to be created
            //            using dictionaries of combinable objects, correct names, etc.
            GameObject newItem = Instantiate(itemPrefab, transform);
            newItem.name = "TestItem4";
            newItem.transform.name = "TestItem4";

            // Adding the new item to the list of inventory in the backend list
            aSystem.AddItem(newItem);
        }
    }
}
