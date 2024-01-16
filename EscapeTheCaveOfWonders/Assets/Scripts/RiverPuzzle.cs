using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverPuzzle : MonoBehaviour
{

    public List<Transform> riverIcons = new List<Transform>();
    private bool gotGem = false;

    public void click(int clickIndex){
        riverIcons[clickIndex].Rotate(0,0,90);
        if(checkWin()){
            dropGem();
            GameManager.instance.uiManager.ToggleRiverPuzzlePanel();
        }
    }

    private bool checkWin(){
        for(int i = 0; i < riverIcons.Count; i++){
            if(riverIcons[i].transform.rotation.z != 0){
                return false;
            }
        }
        return true;
    }

    public void dropGem(){
        if(!gotGem){
            // Debug.Log("You win!!");
            Item gem = GameManager.instance.itemManager.GetItemByName("Blue Gem");
            GameManager.instance.player.DropItem(gem);
            gotGem = true;
        }
    }
}
