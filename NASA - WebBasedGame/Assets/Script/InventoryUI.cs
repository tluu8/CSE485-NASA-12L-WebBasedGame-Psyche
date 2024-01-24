using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System;

public class InventoryUI : MonoBehaviour
{
    // Prefab for generating objects to fill visual inventory
    // Testing purposes, mainly
    public GameObject itemPrefab;

    // The main inventory panel housing the 9 slots
    public Transform inventoryPanel;

    // The nine inventory slots. Avoided using an array,
    // as it got tricky trying to make it work
    public Transform inventorySlot1;
    public Transform inventorySlot2;
    public Transform inventorySlot3;
    public Transform inventorySlot4;
    public Transform inventorySlot5;
    public Transform inventorySlot6;
    public Transform inventorySlot7;
    public Transform inventorySlot8;
    public Transform inventorySlot9;

    // The backend inventory variable
    private InventorySystem inventory;

    // Toggler variable to turn inventory screen on and off
    private bool isInventoryVisible = false;

    void Start()
    {
        inventory = FindObjectOfType<InventorySystem>();
        if (inventory == null)
        {
            Debug.LogError("Inventory system not found in the scene!");
        }
        UpdateInventoryUI();
    }

    // Method to change between screens, regular and inventory
    public void ToggleInventory()
    {
        isInventoryVisible = !isInventoryVisible;
        gameObject.SetActive(isInventoryVisible);
        UpdateInventoryUI();
    }

    // Method to search for if an item is already in the frontend inventory
    private bool isFound(String strName)
    {
        foreach (Transform child in inventorySlot1)
        {
            if (child.name == strName) 
            {
                return true;
            }
        }
        foreach (Transform child in inventorySlot2)
        {
            if (child.name == strName)
            {
                return true;
            }
        }
        foreach (Transform child in inventorySlot3)
        {
            if (child.name == strName)
            {
                return true;
            }
        }
        foreach (Transform child in inventorySlot4)
        {
            if (child.name == strName)
            {
                return true;
            }
        }
        foreach (Transform child in inventorySlot5)
        {
            if (child.name == strName)
            {
                return true;
            }
        }
        foreach (Transform child in inventorySlot6)
        {
            if (child.name == strName)
            {
                return true;
            }
        }
        foreach (Transform child in inventorySlot7)
        {
            if (child.name == strName)
            {
                return true;
            }
        }
        foreach (Transform child in inventorySlot8)
        {
            if (child.name == strName)
            {
                return true;
            }
        }
        foreach (Transform child in inventorySlot9)
        {
            if (child.name == strName)
            {
                return true;
            }
        }

        return false;
    }

    // Updating InventoryUI or frontend inventory every time it is summoned
    private void UpdateInventoryUI()
    {
        // Local function to find the next available slot
        // Currently limited to 9 slots
        // Need potential limiting of items or prevent pickup,
        // as overload will occur on 9th slot
        Transform getOpenSlot()
        {
            if (inventorySlot1.childCount == 0)
            {
                return inventorySlot1;
            }
            else if (inventorySlot2.childCount == 0) 
            {
                return inventorySlot2;
            }
            else if (inventorySlot3.childCount == 0)
            {
                return inventorySlot3;
            }
            else if (inventorySlot4.childCount == 0)
            {
                return inventorySlot4;
            }
            else if (inventorySlot5.childCount == 0)
            {
                return inventorySlot5;
            }
            else if (inventorySlot6.childCount == 0)
            {
                return inventorySlot6;
            }
            else if (inventorySlot7.childCount == 0)
            {
                return inventorySlot7;
            }
            else if (inventorySlot8.childCount == 0)
            {
                return inventorySlot8;
            }
            /*else if (inventorySlot9.childCount == 0)
            {
                return inventorySlot9;
            }*/
            else
            {
                return inventorySlot9;
            }
            
        }

        // Create a new UI element for each item
        try
        {
            for (int i = 0; i < inventory.items.Count; i++)
            {
                //Debug.Log("Check " + i + "a");
                if (!isFound(inventory.items[i].name))
                {
                    var item = inventory.items[i];
                    GameObject newItem = Instantiate(itemPrefab, getOpenSlot());
                    //GameObject newItem = Instantiate(inventory.items[i], getOpenSlot());
                    newItem.name = item.name;
                    Image itemText = newItem.GetComponent<Image>();
                }
            }
        }
        // Currently unsure why this exception is being thrown, but didn't affect gameplay
        // from what could be determined. Catching it so that it is separated from other errors
        catch (NullReferenceException)
        {
            Debug.Log("Null reference thrown");
        }
    }

}
