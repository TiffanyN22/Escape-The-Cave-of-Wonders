using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Item))]
public class Collectable : MonoBehaviour
{
    //player walks int ocllectable
    //add to player
    //delete from screen
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //get player info off of collision object 
        Player player = collision.GetComponent<Player>();
        if (player) //player inside trigger
        {
            Item item = GetComponent<Item>();
            if (item != null)
            {
                if(player.inventory.Add("Toolbar", item)){
                    GameManager.instance.uiManager.RefreshInventoryUI("Toolbar");
                } else{
                    player.inventory.Add("Backpack", item);
                }
                Destroy(this.gameObject);
            }
        }
    }
}