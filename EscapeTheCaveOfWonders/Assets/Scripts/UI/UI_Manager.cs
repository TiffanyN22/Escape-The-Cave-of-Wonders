using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public Dictionary<string, Inventory_UI> inventoryUIByName = new Dictionary<string, Inventory_UI>();

    public List<Inventory_UI> inventoryUIs;

    public GameObject inventoryPanel;
    public GameObject removeItemPanel;
    public GameObject paperStand;
    public GameObject gobletStand;

    public static Slot_UI draggedSlot;
    public static Image draggedIcon;
    public static bool dragSingle;

    public void Awake()
    {
        Initialize();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.B))
        {
            if(!paperStand.activeSelf && !gobletStand.activeSelf){
                ToggleInventory();
            }
            else if(gobletStand.activeSelf){
                ToggleGobletStand(); //close goblet stand if it's open
            }
            else{
                TogglePaperStand(); //close paper stand if it's open
            }
        }
        if(Input.GetKeyDown(KeyCode.P)){ //TODO: open paper stand with in-game element
            TogglePaperStand();
        }
        if(Input.GetKeyDown(KeyCode.G)){ //TODO: open goblet stand with in-game element
            ToggleGobletStand();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            dragSingle = true;
        }
        else
        {
            dragSingle = false;
        }
    }

    public void ToggleInventory()
    {
        //if(inventoryPanel != null) --> if inventory
        //if (slots.Count == inventory.slots.Count)
        if (inventoryPanel != null)
        {
            if (!inventoryPanel.activeSelf)
            {
                inventoryPanel.SetActive(true);
                RefreshInventoryUI("Backpack");
            }
            else
            {
                inventoryPanel.SetActive(false);
            }
        }

        if (removeItemPanel != null)
        {
            removeItemPanel.SetActive(!removeItemPanel.activeSelf);
        }
    }

    public void TogglePaperStand(){
        if(!paperStand){
            return;
        }
        paperStand.SetActive(!paperStand.activeSelf);
    }

    public void ToggleGobletStand(){
        if(!gobletStand){
            return;
        }
        gobletStand.SetActive(!gobletStand.activeSelf);
    }

    public void RefreshInventoryUI(string inventoryName)
    {
        if (inventoryUIByName.ContainsKey(inventoryName))
        {
            inventoryUIByName[inventoryName].Refresh();
        }
    } 

    public void RefreshAll()
    {
        foreach(KeyValuePair<string, Inventory_UI> keyValuePair in inventoryUIByName)
        {
            keyValuePair.Value.Refresh();
        }
    }

    public Inventory_UI GetInventoryUI(string inventoryName)
    {
        if (inventoryUIByName.ContainsKey(inventoryName))
        {
            return inventoryUIByName[inventoryName];
        }
        Debug.LogWarning("There is no inventory ui for " + inventoryName);
        return null;
    }

    void Initialize()
    {
        foreach(Inventory_UI ui in inventoryUIs)
        {
            if (!inventoryUIByName.ContainsKey(ui.inventoryName))
            {
                inventoryUIByName.Add(ui.inventoryName, ui);
            }
        }
    }
}
