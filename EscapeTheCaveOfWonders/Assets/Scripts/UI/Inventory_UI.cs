using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_UI : MonoBehaviour
{
    //public GameObject inventoryPanel;
    public string inventoryName;

    public List<Slot_UI> slots = new List<Slot_UI>();
    [SerializeField] private Canvas canvas;
    //private static Slot_UI draggedSlot;
    //private static Image draggedIcon;
    //private bool dragSingle;

    private Inventory inventory;


    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>();
    }
    public void Start()
    {
        inventory = GameManager.instance.player.inventory.GetInventoryByName(inventoryName);

        SetUpSlots();
        Refresh();
    }

    //ui match inventory
    public void Refresh()
    {
        if (slots.Count == inventory.slots.Count)
        {
            for(int i = 0; i < slots.Count; i++)
            {
                if(inventory.slots[i].itemName != "")
                {
                    slots[i].SetItem(inventory.slots[i]);
                }
                else
                {
                    slots[i].SetEmpty();
                }
            }
        }
        else
        {
            Debug.Log("slot count" + slots.Count);
            Debug.Log("inventory count" + inventory.slots.Count);
        }
    }

    public void Remove()
    {
        Item itemToDrop = GameManager.instance.itemManager.GetItemByName
            (inventory.slots[UI_Manager.draggedSlot.slotID].itemName);
        if (itemToDrop != null)
        {
            if (UI_Manager.dragSingle)
            {
                GameManager.instance.player.DropItem(itemToDrop);
                inventory.Remove(UI_Manager.draggedSlot.slotID);
            }
            else
            {
                GameManager.instance.player.DropItem(itemToDrop, inventory.slots[UI_Manager.draggedSlot.slotID].count);
                inventory.Remove(UI_Manager.draggedSlot.slotID,
                    inventory.slots[UI_Manager.draggedSlot.slotID].count);
            }
            Refresh();
        }

        UI_Manager.draggedSlot = null;
    }

    public void SlotBeginDrag(Slot_UI slot)
    {
        UI_Manager.draggedSlot = slot;
        UI_Manager.draggedIcon = Instantiate(UI_Manager.draggedSlot.itemIcon);
        UI_Manager.draggedIcon.transform.SetParent(canvas.transform); //child of canvas
        UI_Manager.draggedIcon.raycastTarget = false;
        UI_Manager.draggedIcon.SetNativeSize();
        UI_Manager.draggedIcon.rectTransform.sizeDelta = new Vector2(40, 40);


        MoveToMousePosition(UI_Manager.draggedIcon.gameObject);

        //Debug.Log("Start Drag: " + draggedSlot.name);
    }
     
    public void SlotDrag() //mouse moving
    {
        MoveToMousePosition(UI_Manager.draggedIcon.gameObject);
        //Debug.Log("Dragging: " + draggedSlot.name);
    }

    public void SlotEndDrag()
    {
        Destroy(UI_Manager.draggedIcon.gameObject);
        UI_Manager.draggedIcon = null;

        //Debug.Log("Done Dragging: " + draggedSlot.name);
    }

    public void SlotDrop(Slot_UI slot)
    {
        if (UI_Manager.dragSingle) 
        {
            UI_Manager.draggedSlot.inventory.MoveSlot(UI_Manager.draggedSlot.slotID, slot.slotID, slot.inventory);
        }
        else
        {
            UI_Manager.draggedSlot.inventory.MoveSlot(UI_Manager.draggedSlot.slotID, slot.slotID, slot.inventory,
                UI_Manager.draggedSlot.inventory.slots[UI_Manager.draggedSlot.slotID].count);
        }
        GameManager.instance.uiManager.RefreshAll();
        //Debug.Log("Done Dragging: " + draggedSlot.name + " on" + slot.name);
    }

    private void MoveToMousePosition(GameObject toMove)
    {
        if(canvas != null)
        {
            Vector2 position;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform,
                Input.mousePosition, null, out position);
            toMove.transform.position = canvas.transform.TransformPoint(position); //pass local point to get world point
        }
    }

    private void SetUpSlots()
    {
        int counter = 0;
        foreach(Slot_UI slot in slots)
        {
            slot.slotID = counter;
            counter++;
            slot.inventory = inventory;
        }
    }
}
