using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
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
        if (inventory != null && isInventoryVisible)
        {
            // Here you would update the UI elements to represent the items in the inventory.
            // For now, just logging the items to the console.
            Debug.Log("Inventory Items:");
            foreach (var item in inventory.items)
            {
                Debug.Log(item.name);
            }
        }
    }
}
