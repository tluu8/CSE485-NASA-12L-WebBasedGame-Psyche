using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JetBrains.Annotations;
using System.IO;
using Unity.VisualScripting;

public class InventorySystem : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();
    public List<string> descriptions = new List<string>();
    public List<Texture2D> displayIcons = new List<Texture2D>();
    private int itemNum = 1;

    public void AddItem(GameObject item)
    {
        items.Add(item);
        descriptions.Add("Test Description #" + itemNum);
        Texture2D iconToAdd = new Texture2D(16, 16);
        iconToAdd = Texture2D.blackTexture;
        displayIcons.Add(iconToAdd);
        itemNum++;
    }
}
