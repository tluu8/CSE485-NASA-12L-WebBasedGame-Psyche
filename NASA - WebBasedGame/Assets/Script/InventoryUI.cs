using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{

    public GameObject itemPrefab;
    public Transform inventoryPanel;
    private InventorySystem inventory;
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

    public void ToggleInventory()
    {
        isInventoryVisible = !isInventoryVisible;
        gameObject.SetActive(isInventoryVisible);
        UpdateInventoryUI();
    }

    private void UpdateInventoryUI()
    {
        // Clear existing items
        foreach (Transform child in inventoryPanel)
        {
            Destroy(child.gameObject);
        }

        // Create a new UI element for each item
        foreach (var item in inventory.items)
        {
            GameObject newItem = Instantiate(itemPrefab, inventoryPanel);
            TextMeshProUGUI itemText = newItem.GetComponent<TextMeshProUGUI>();
            itemText.text = item.name;
        }
    }

}