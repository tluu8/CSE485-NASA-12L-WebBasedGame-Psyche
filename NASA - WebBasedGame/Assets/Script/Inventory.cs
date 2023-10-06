using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    enum Type    
    {
        DocA,
        DocB,
        DocC,
        DocD
    }
    public class Item
    {
        string name;
        Type aType;
    }
    public class Slot
    {
        Item item;
        int slotNum;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
