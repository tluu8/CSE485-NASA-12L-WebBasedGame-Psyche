using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public TextMeshProUGUI itemText;
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
            // Clear the existing text
            itemText.text = "";

            // Loop through each item in the inventory and add its name to the text
            foreach (var item in inventory.items)
            {
                itemText.text += item.name + "\n";
            }
        }
    }
}
