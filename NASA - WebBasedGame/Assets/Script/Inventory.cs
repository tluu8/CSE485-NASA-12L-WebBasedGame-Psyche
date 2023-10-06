using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private const int TOTALSLOTS = 12;
    private Slot[] combinedSlots; 

    public enum Type    
    {
        DocA,
        DocB,
        DocC,
        DocD,
        None
    }
    public class Item
    {
        string itemName;
        Type itemType;

        public Item(string aName, Type aType)
        {
            this.itemName = aName;
            this.itemType = aType;
        }
        
        public Item()
        {
            this.itemName = "";
            this.itemType = Type.None;
        }
    }
    public class Slot
    {
        Item item;
        int slotNum;

        public Slot(Item itemToInsert, int currentSlotNumber)
        {
            this.item = itemToInsert;
            this.slotNum = currentSlotNumber;
        }
        public Slot(int currentSlotNumber)
        {
            Item emptyItem = new Item();
            this.item = emptyItem;
            this.slotNum = currentSlotNumber;
        }
    }

    public Inventory()
    {
        combinedSlots = new Slot[TOTALSLOTS];

        for (int i = 0; i < TOTALSLOTS; i++) 
        {
            Slot slotToInsert = new Slot(i + 1);
            combinedSlots[i] = slotToInsert;
        }
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
