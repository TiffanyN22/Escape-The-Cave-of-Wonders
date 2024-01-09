using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //keep track of collectables picked up
    //public int numCarrotSeed = 0;
    public InventoryManager inventory;
    private TileManager tileManager;

    private string[] miningDrops = {"Coin", "Scroll", "Coin", "Coin", "Scroll", "Scroll", "Coin", "Scroll", "Scroll", "Coin"};
    public string[] gemPlaced = {"", "", "", ""}; //TODO: make private
    private string[] correctGemOrder = {"Purple", "Green", "Red", "Blue"};
    private int rocksMined = 0;
    private int borderRocksMined = 0;
    private bool escaped = false;

    private void Start()
    {
        tileManager = GameManager.instance.tileManager;
    }

    //new inventory when starting the game
    private void Awake()
    {
        inventory = GetComponent<InventoryManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (tileManager != null)
            {
                Vector3Int position = new Vector3Int((int)transform.position.x,
                (int)transform.position.y, 0);

                string tileName = tileManager.GetTileName(position);

                if (!string.IsNullOrWhiteSpace(tileName))
                {
                    if (tileName == "Interactable" && 
                        (inventory.toolbar.selectedSlot.itemName == "Pickaxe" ||inventory.toolbar.selectedSlot.itemName == "Enchanted Pickaxe"))
                    {
                        //TODO: this logic with the breaking stone with pickaxe
                        Debug.Log("breaking rock interactable");
                        if(rocksMined < miningDrops.Length){
                            Debug.Log("dropping item");
                            Item dropItem = GameManager.instance.itemManager.GetItemByName(miningDrops[rocksMined++]);
                            GameManager.instance.player.DropItem(dropItem);
                        }

                        tileManager.SetInteracted(position);
                    } 
                    else if(tileName == "Border_Rock_Interactable" && 
                        (inventory.toolbar.selectedSlot.itemName == "Pickaxe" ||inventory.toolbar.selectedSlot.itemName == "Enchanted Pickaxe")){
                        tileManager.SetInteracted(position);
                        borderRocksMined++;
                        if (borderRocksMined == 2){
                            Physics2D.IgnoreLayerCollision(6,7);
                        }
                    }
                    else if (tileName == "Special_Rock_Interactable" && inventory.toolbar.selectedSlot.itemName == "Enchanted Pickaxe"){
                        Item greenGem = GameManager.instance.itemManager.GetItemByName("Green Gem");
                        GameManager.instance.player.DropItem(greenGem);
                        tileManager.SetInteracted(position);
                    }
                    else if (tileName == "Paper_Stand_Interactable" && inventory.toolbar.selectedSlot.itemName == "Scroll"
                        && inventory.toolbar.selectedSlot.count >= 2) //TODO: count is 9
                    {
                        GameManager.instance.uiManager.TogglePaperStand();
                    }
                    else if (tileName == "Paper_Stand_Interactable" && inventory.toolbar.selectedSlot.itemName == "Treasure Map")
                    {
                        GameManager.instance.uiManager.ToggleTreasureMapPanel();
                    }
                    else if(tileName == "Stream_Interactable" && inventory.toolbar.selectedSlot.itemName == "Pickaxe"){
                        inventory.toolbar.selectedSlot.RemoveAll();

                        Item enchantedPickaxe = GameManager.instance.itemManager.GetItemByName("Enchanted Pickaxe");
                        inventory.toolbar.selectedSlot.AddItem(enchantedPickaxe);
                        GameManager.instance.uiManager.RefreshInventoryUI("Toolbar");
                    }
                    else if(tileName == "Hourglass_Interactable"){
                        GameManager.instance.uiManager.ToggleHourglassRearrangePanel();
                    }
                    else if(tileName == "Painting_Interactable"){
                        GameManager.instance.uiManager.ToggleHourglassPaintingPanel();
                    }
                    else if (tileName == "Trader_Interactable"){
                        GameManager.instance.uiManager.ToggleTradePanel();
                    }
                    else if(tileName == "Goblet_Stand_Interactable"){
                        GameManager.instance.uiManager.ToggleGobletStand();
                    }
                    else if (tileName.Contains("Gem_Interactable") && inventory.toolbar.selectedSlot.itemName.Contains("Gem")){
                        // Debug.Log("The gems are interacting");
                        PlaceGem(tileName);
                    }
                    else if (tileName.Contains("Gem_Interactable")){
                        // Debug.Log("The gems are interacting");
                        SetGemTile(tileName);
                    }
                    
                }
            }
        } 
    }

    public void DropItem(Item item)
    {
        Vector2 spawnLocation = transform.position;
        //Vector2 spawnOffset = Random.insideUnitCircle * 1.2f;
        Vector2 spawnOffset = new Vector2(1f, Random.Range(-1f, 0f));

        Item droppedItem = Instantiate(item, spawnLocation + spawnOffset, 
            Quaternion.identity);
        droppedItem.rb2d.AddForce(spawnOffset * 1f, ForceMode2D.Impulse);
   }

    public void DropItem(Item item, int numToDrop)
    {
        for(int i = 0; i < numToDrop; i++)
        {
            DropItem(item);
        }
    }

    //GEM PUZZLE CODE
    public void PlaceGem(string tileName){
        switch(inventory.toolbar.selectedSlot.itemName){
            case "Blue Gem":
                Debug.Log("Placing Blue Gem");
                SetGemTile(tileName, "Blue");
                break;
            case "Green Gem":
                Debug.Log("Placing Green Gem");
                SetGemTile(tileName, "Green");
                break;
            case "Purple Gem":
                Debug.Log("Placing Purple Gem");
                SetGemTile(tileName, "Purple");
                break;
            case "Red Gem":
                Debug.Log("Placing Red Gem");
                SetGemTile(tileName, "Red");
                break;
        }
    }

    public void SetGemTile(string tileName, string gemColor = ""){
        switch (tileName){
            case "Purple_Gem_Interactable":
                if(gemPlaced[0] == "" && !string.IsNullOrWhiteSpace(gemColor)){
                    SetGem(0, gemColor);
                } else if (gemPlaced[0] != "") {
                    RemoveGem(0);
                }
                break;
            case "Green_Gem_Interactable":
                if(gemPlaced[1] == "" && !string.IsNullOrWhiteSpace(gemColor)){
                    SetGem(1, gemColor);
                } else if (gemPlaced[1] != "") {
                    RemoveGem(1);
                }
                break;
            case "Red_Gem_Interactable":
                if(gemPlaced[2] == "" && !string.IsNullOrWhiteSpace(gemColor)){
                    SetGem(2, gemColor);
                } else if (gemPlaced[2] != "") {
                    RemoveGem(2);
                }
                break;
            case "Blue_Gem_Interactable":
                if(gemPlaced[3] == "" && !string.IsNullOrWhiteSpace(gemColor)){
                    SetGem(3, gemColor);
                } 
                else if (gemPlaced[3] != "") {
                    RemoveGem(3);
                }
                break;
        }
    }

    private void RemoveGem(int index){
        Vector3Int position = new Vector3Int((int)transform.position.x, (int)transform.position.y, 0);
        Item gem = GameManager.instance.itemManager.GetItemByName(gemPlaced[index] + " Gem");
        DropItem(gem);
        gemPlaced[index] = "";
        tileManager.SetGem(position, "None");
    }

    private void SetGem(int index, string gemColor){
        Vector3Int position = new Vector3Int((int)transform.position.x, (int)transform.position.y, 0);
        gemPlaced[index] = gemColor;
        tileManager.SetGem(position, gemColor);
        inventory.toolbar.selectedSlot.RemoveAll();
        GameManager.instance.uiManager.RefreshInventoryUI("Toolbar");
        checkWin();
    }

    private void checkWin(){
        for(int i = 0; i < gemPlaced.Length; i++){
            if(gemPlaced[i] != correctGemOrder[i]){
                return;
            }
        }
        if(!escaped){
            GameManager.instance.uiManager.ToggleVictoryPanel();
            escaped = true;
        }
    }
}
