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
    public GameObject tradePanel;
    public GameObject hourglassPaintingPanel;
    public GameObject hourglassRearrangePanel;
    public GameObject treasureMapPanel;
    public GameObject vaultCluePanel;
    public GameObject victoryPanel;
    public GameObject howToPlayPanel;
    public GameObject openingPanel;
    public GameObject riverPuzzlePanel;

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
            //Close whichever is open
            if(paperStand.activeSelf){
                TogglePaperStand();
            }
            else if(gobletStand.activeSelf){
                ToggleGobletStand();
            }
            else if(tradePanel.activeSelf){
                ToggleTradePanel();
            }
            else if (hourglassPaintingPanel.activeSelf){
                ToggleHourglassPaintingPanel();
            }
            else if(hourglassRearrangePanel.activeSelf){
                ToggleHourglassRearrangePanel();
            }
            else if(treasureMapPanel.activeSelf){
                ToggleTreasureMapPanel();
            }
            else if(vaultCluePanel.activeSelf){
                ToggleVaultCluePanel();
            } 
            else if (howToPlayPanel.activeSelf){
                SetHowToPlayPanel(false);
            } else if(riverPuzzlePanel.activeSelf){
                ToggleRiverPuzzlePanel();
            }
            else{
                ToggleInventory();
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            dragSingle = true;
        }
        else
        {
            dragSingle = false;
        }

        if(Input.GetKey(KeyCode.Escape)){
            SetHowToPlayPanel(true);
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

    public void ToggleTradePanel(){
        if(tradePanel == null){
            return;
        }
        tradePanel.SetActive(!tradePanel.activeSelf);
    }

    public void ToggleHourglassPaintingPanel(){
        if(hourglassPaintingPanel == null){
            return;
        }
        hourglassPaintingPanel.SetActive(!hourglassPaintingPanel.activeSelf);
    }

    public void ToggleHourglassRearrangePanel(){
        if(hourglassRearrangePanel == null){
            return;
        }
        hourglassRearrangePanel.SetActive(!hourglassRearrangePanel.activeSelf);
    }

    public void ToggleTreasureMapPanel(){
        if(treasureMapPanel == null){
            return;
        }
        treasureMapPanel.SetActive(!treasureMapPanel.activeSelf);
    }

    public void ToggleVaultCluePanel(){
        if(vaultCluePanel == null){
            return;
        }
        vaultCluePanel.SetActive(!vaultCluePanel.activeSelf);
    }

    public void ToggleRiverPuzzlePanel(){
        if (riverPuzzlePanel == null){
            return;
        }
        riverPuzzlePanel.SetActive(!riverPuzzlePanel.activeSelf);
    }

    public void SetVictoryPanel(){
        if(victoryPanel == null){
            return;
        }
        victoryPanel.SetActive(true);
    }

    public void SetHowToPlayPanel(bool set){
        if(howToPlayPanel == null){
            return;
        }
        howToPlayPanel.SetActive(set);
    }

    public void SetOpeningPanel(bool set){
        if(openingPanel == null){
            return;
        }
        openingPanel.SetActive(set);
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
        // Debug.Log("Refresh all");
        foreach(KeyValuePair<string, Inventory_UI> keyValuePair in inventoryUIByName)
        {
            // Debug.Log(keyValuePair.Key);
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
