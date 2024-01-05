using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourglassRearrange : MonoBehaviour
{
    public List<HourglassPuzzlePiece> allPuzzlePeices = new List<HourglassPuzzlePiece>();
    public List<Sprite> allSprites = new List<Sprite>(); //order doesn't change
    public int[] idOrder = {0,1,2,3,4}; //order changes based on user clicks
    private int firstSelectIndex = -1;
    private int[] correctOrder = {4,2,0,1,3};
    private bool gotGem = false;

    public void click(int clickedIndex){
        if (allPuzzlePeices == null){
            Debug.Log("allPuzzlePeices is null");
            return;
        }

        if (firstSelectIndex == -1){
            firstSelectIndex = clickedIndex;
            allPuzzlePeices[clickedIndex].tintImage(true);
        } else{
            allPuzzlePeices[firstSelectIndex].tintImage(false);

            allPuzzlePeices[firstSelectIndex].updateImage(allSprites[idOrder[clickedIndex]]);
            allPuzzlePeices[clickedIndex].updateImage(allSprites[idOrder[firstSelectIndex]]);

            int clickTemp = idOrder[clickedIndex];
            idOrder[clickedIndex] = idOrder[firstSelectIndex];
            idOrder[firstSelectIndex] = clickTemp;

            firstSelectIndex = -1;

            checkOrder();
        }

    }

    public bool isCorrectOrder(){
        if(idOrder.Length != correctOrder.Length){
            Debug.Log("Hourglass Rearrange: idOrder and correctOrder have different lengths!");
            return false;
        }
        for(int i = 0; i < correctOrder.Length; i++){
            if(idOrder[i] != correctOrder[i]){
                return false;
            }
        }
        return true;
    }

    public void checkOrder(){
        if(isCorrectOrder() && !gotGem){
            Debug.Log("You win!!");

            Item gem = GameManager.instance.itemManager.GetItemByName("Blue Gem");
            GameManager.instance.player.DropItem(gem);
            GameManager.instance.uiManager.ToggleHourglassRearrangePanel();
            gotGem = true;
        }
    }
}
