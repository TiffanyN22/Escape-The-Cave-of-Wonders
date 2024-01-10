using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Monkey : MonoBehaviour
{
    [SerializeField] public Sprite imgSprite;
    public SpriteRenderer render;
    private bool droppedAxe = false;

    void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        if (!droppedAxe && GameManager.instance.player.inventory.toolbar.selectedSlot.itemName == "Key")
        {
            Debug.Log("clicked!");
            render.sprite = imgSprite;

            Item pickaxe = GameManager.instance.itemManager.GetItemByName("Pickaxe");
            Vector2 spawnLocation = transform.position;
            Vector2 spawnOffset = new Vector2(1f, Random.Range(-1f, 0f));

            Item droppedItem = Instantiate(pickaxe, spawnLocation + spawnOffset, 
                Quaternion.identity);
            droppedItem.rb2d.AddForce(spawnOffset * 1f, ForceMode2D.Impulse);
            droppedAxe = true;
        
        }

    }
}