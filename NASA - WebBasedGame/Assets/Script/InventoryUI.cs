using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;


public class InventoryUI : MonoBehaviour
{

    public GameObject itemPrefab;
    public Transform inventoryPanel;
    public Transform inventorySlot1;
    public Transform inventorySlot2;
    public Transform inventorySlot3;
    public Transform inventorySlot4;
    public Transform inventorySlot5;
    public Transform inventorySlot6;
    public Transform inventorySlot7;
    public Transform inventorySlot8;
    public Transform inventorySlot9;
    private InventorySystem inventory;
    private bool isInventoryVisible = false;
    //Transform[] slots = new Transform[9];

    void Start()
    {
        inventory = FindObjectOfType<InventorySystem>();
        if (inventory == null)
        {
            Debug.LogError("Inventory system not found in the scene!");
        }


        UpdateInventoryUI();
    }

    public void ToggleInventory()
    {
        isInventoryVisible = !isInventoryVisible;
        gameObject.SetActive(isInventoryVisible);
        UpdateInventoryUI();
        if (!isInventoryVisible)
        {
            foreach (Transform child in inventorySlot1)
            {
                Destroy(child.gameObject);
            }
            foreach (Transform child in inventorySlot2)
            {
                Destroy(child.gameObject);
            }
            foreach (Transform child in inventorySlot3)
            {
                Destroy(child.gameObject);
            }
            foreach (Transform child in inventorySlot4)
            {
                Destroy(child.gameObject);
            }
            foreach (Transform child in inventorySlot5)
            {
                Destroy(child.gameObject);
            }
            foreach (Transform child in inventorySlot6)
            {
                Destroy(child.gameObject);
            }
            foreach (Transform child in inventorySlot7)
            {
                Destroy(child.gameObject);
            }
            foreach (Transform child in inventorySlot8)
            {
                Destroy(child.gameObject);
            }
        }
    }

    private void UpdateInventoryUI()
    {
        // Clear existing items
        //foreach (Transform child in inventoryPanel)
        //{
        //Destroy(child.gameObject);
        //}

        foreach (Transform child in inventorySlot1)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in inventorySlot2)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in inventorySlot3)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in inventorySlot4)
        { 
            Destroy(child.gameObject); 
        }
        foreach (Transform child in inventorySlot5)
        { 
            Destroy(child.gameObject); 
        }
        foreach (Transform child in inventorySlot6)
        { 
            Destroy(child.gameObject); 
        }
        foreach (Transform child in inventorySlot7)
        { 
            Destroy(child.gameObject); 
        }
        foreach (Transform child in inventorySlot8)
        { 
            Destroy(child.gameObject); 
        }

        Transform getOpenSlot(int slotNum)
        {

            if (slotNum == 0)
            {
                return inventorySlot1;
            }
            else if (slotNum == 1)
            {
                return inventorySlot2;
            }
            else if (slotNum == 2)
            {
                return inventorySlot3;
            }
            else if (slotNum == 3)
            {
                return inventorySlot4;
            }
            else if (slotNum == 4)
            {
                return inventorySlot5;
            }
            else if (slotNum == 5)
            {
                return inventorySlot6;
            }
            else if (slotNum == 6)
            {
                return inventorySlot7;
            }
            else if (slotNum == 7)
            {
                return inventorySlot8;
            }
            else
            {
                return inventorySlot9;
            }
            /*
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
            else
            {
                return inventorySlot9;
            }
            */
        }



        // Create a new UI element for each item
        //foreach (var item in inventory.items)
        for (int i = 0; i<inventory.items.Count; i++)
        {
            var item = inventory.items[i];
            var itemDesc = inventory.descriptions[i];
            GameObject newItem = Instantiate(itemPrefab, getOpenSlot(i));
            Image itemText = newItem.GetComponent<Image>();
            //TextMeshProUGUI itemText = newItem.GetComponent<TextMeshProUGUI>();           
            //itemText.text = item.name + " - " + itemDesc;
        }
    }

}
