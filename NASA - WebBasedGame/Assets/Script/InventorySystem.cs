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
    private int itemNum = 1;

    public void AddItem(GameObject item)
    {
        items.Add(item);
        descriptions.Add(item.name, "Test Description #" + itemNum);
        itemNum++;
    }
}
