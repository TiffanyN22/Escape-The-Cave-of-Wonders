using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] public Sprite brokenRock;
    [SerializeField] public string itemToDrop;
    [SerializeField] public bool isSpecialRock;
    public SpriteRenderer render;
    private bool brokeRock = false;

    void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        Debug.Log("ROCKKKK On Mouse Down");
        if (!brokeRock && (GameManager.instance.player.inventory.toolbar.selectedSlot.itemName == "Enchanted Pickaxe" ||
            (GameManager.instance.player.inventory.toolbar.selectedSlot.itemName == "Pickaxe" && !isSpecialRock)))
            {
            render.sprite = brokenRock;
            GetComponent<Collider2D>().enabled = false;

            if(!string.IsNullOrWhiteSpace(itemToDrop)){
                Item dropItem = GameManager.instance.itemManager.GetItemByName(itemToDrop);
                Vector2 spawnLocation = transform.position;
                Vector2 spawnOffset = new Vector2(1f, Random.Range(-1f, 0f));

                Item droppedItem = Instantiate(dropItem, spawnLocation + spawnOffset, 
                    Quaternion.identity);
                droppedItem.rb2d.AddForce(spawnOffset * 1f, ForceMode2D.Impulse);
                brokeRock = true;
            }
        }

    }
}
