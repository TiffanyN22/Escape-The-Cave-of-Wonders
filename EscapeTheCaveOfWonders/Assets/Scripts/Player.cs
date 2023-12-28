using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //keep track of collectables picked up
    //public int numCarrotSeed = 0;
    public InventoryManager inventory;
    private TileManager tileManager;

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
                    if (tileName == "Interactable" && inventory.toolbar.selectedSlot.itemName == "Hoe")
                    {
                        tileManager.SetInteracted(position);
                    }
                }

                //if (GameManager.instance.tileManager.IsInteractable(position))
                //{
                //    Debug.Log("Tile is interactable");
                //    GameManager.instance.tileManager.SetInteracted(position);
                //}
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
}
