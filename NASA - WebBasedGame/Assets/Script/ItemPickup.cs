using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PickupItem(collision.gameObject);
        }
    }

    private void PickupItem(GameObject player)
    {
        InventorySystem inventory = FindObjectOfType<InventorySystem>();
        if (inventory != null)
        {
            inventory.AddItem(gameObject);
        }
        gameObject.SetActive(false);
    }
}
