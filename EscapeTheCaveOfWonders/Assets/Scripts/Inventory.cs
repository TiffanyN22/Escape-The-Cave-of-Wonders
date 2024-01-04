using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//to see in inspector
[System.Serializable]
public class Inventory
{
    [System.Serializable]
    public class Slot
    {
        public string itemName;
        public int count; //num of items in slot
        public int maxAllowed;

        public Sprite icon;

        public Slot()
        {
            itemName = "";
            count = 0;
            maxAllowed = 99;
        }

        public bool IsEmpty
        {
            get
            {
                if(itemName == "" && count == 0)
                {
                    return true;
                }
                return false;
            }
        }
        public bool CanAddItem(string itemName )
        {
            return (this.itemName == itemName && count < maxAllowed);
        }

        public void AddItem(Item item)
        {
            this.itemName = item.data.itemName;
            this.icon = item.data.icon;
            count++;
        }

        public void AddItem(string itemName, Sprite icon, int maxAllowed)
        {
            this.itemName = itemName;
            this.icon = icon;
            count++;
            this.maxAllowed = maxAllowed;
        }

        public void RemoveItem()
        {
            if(count > 0) //remove if nothing inside
            {
                count--;

                //remove icon if empty
                if(count == 0)
                {
                    icon = null;
                    itemName = "";
                }
            }
        }

        public void RemoveAll(){
            count = 0;
            icon = null;
            itemName = "";
        }
    }

    public List<Slot> slots = new List<Slot>();
    public Slot selectedSlot = null; //TODO: make private

    //constructor
    public Inventory(int numSlots)
    {
        //create slots
        for (int i = 0; i < numSlots; i++)
        {
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }
    
    public void Add(Item item)
    {
        //check if item exists and can add
        foreach(Slot slot in slots)
        {
            if(slot.itemName == item.data.itemName && slot.CanAddItem(item.data.itemName))
            {
                slot.AddItem(item);
                return;
            }
        }

        //add if need a new slot
        foreach(Slot slot in slots)
        {
            if(slot.itemName == "")
            {
                slot.AddItem(item);
                return;
            }
        }
    }

    public void Remove(int index)
    {
        slots[index].RemoveItem();
    }

    public void Remove(int index, int numToRemove)
    {
        if(slots[index].count >= numToRemove)
        {
            for(int i = 0; i < numToRemove; i++)
            {
                Remove(index);
            }
        }
    }

    public void MoveSlot(int fromIndex, int toIndex, Inventory toInventory, int numToMove = 1)
    {
        Slot fromSlot = slots[fromIndex];
        Slot toSlot = toInventory.slots[toIndex];

        if(toSlot.IsEmpty || toSlot.CanAddItem(fromSlot.itemName))
        {
            for (int i = 0; i < numToMove; i++)
            {
                toSlot.AddItem(fromSlot.itemName, fromSlot.icon, fromSlot.maxAllowed);
                fromSlot.RemoveItem();
            }
            CheckTradeSuccess(toIndex, toInventory);
        }
    }

    public void SelectSlot(int index)
    {
        if(slots != null && slots.Count > 0)
        {
            selectedSlot = slots[index];
        }
    }

    public void CheckTradeSuccess(int toIndex, Inventory toInventory){
        //means that its trade --> make more official way with name?
        if(toInventory.slots.Count == 1){
            Slot toSlot = toInventory.slots[toIndex];
            // Debug.Log("trading!");

            //TODO: require 9 coins
            int tradeCoinsRequired = 2;
            if(toSlot.itemName == "Coin" && toSlot.count >= tradeCoinsRequired){
                //Gives user flying carpet
                Item carpet = GameManager.instance.itemManager.GetItemByName("Flying Carpet");
                GameManager.instance.player.DropItem(carpet);
                GameManager.instance.uiManager.ToggleTradePanel(); //close trade panel
                toSlot.RemoveAll(); //removes coins from trade panel
            }
        }
    }

}
