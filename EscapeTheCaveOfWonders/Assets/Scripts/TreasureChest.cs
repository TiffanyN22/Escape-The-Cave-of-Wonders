using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    [SerializeField] public Sprite imgSprite;
    public SpriteRenderer render;
    private bool droppedKey = false;

    void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        GameManager.instance.uiManager.ToggleLockPuzzlePanel();
    }

    public void DropKey()
    {
        if (!droppedKey)
        {
            render.sprite = imgSprite;

            Item key = GameManager.instance.itemManager.GetItemByName("Key");
            Vector2 spawnLocation = transform.position;
            Vector2 spawnOffset = new Vector2(1f, Random.Range(0f, 1f));

            Item droppedItem = Instantiate(key, spawnLocation + spawnOffset, 
                Quaternion.identity);
            droppedItem.rb2d.AddForce(spawnOffset * 1f, ForceMode2D.Impulse);
            droppedKey = true;
        
        }
    }
}
