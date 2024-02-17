using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JetBrains.Annotations;
using System.IO;
using Unity.VisualScripting;

public class InventorySystem : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();
    public Dictionary<string, string> descriptions = new Dictionary<string, string>();
    public Dictionary<string, string> combinableItems = new Dictionary<string, string>();
    //public Dictionary<string, string> imageSprites = new Dictionary<string, string>();
    private int itemNum = 1;

    private void Start()
    {
        combinableItems.Add("TestItem1", "TestItem3");
        combinableItems.Add("TestItem3", "TestItem1");
        combinableItems.Add("Blackbox", "Notes");
        combinableItems.Add("Notes", "Blackbox");
        combinableItems.Add("TestItem2", " ");
        combinableItems.Add("ASU Trinket", " ");
        combinableItems.Add("Satellite", " ");
        combinableItems.Add("TestItem4", " ");
    }

    public void AddItem(GameObject item)
    {
        items.Add(item);
        descriptions.Add(item.name, "Test Description #" + itemNum);
        itemNum++;
    }
}
