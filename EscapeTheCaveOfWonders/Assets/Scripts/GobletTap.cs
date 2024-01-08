using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GobletTap : MonoBehaviour
{
    private int[] correctOrder = { 3, 0, 2, 5, 1, 4 };
    private int correctCount = 0;
    [SerializeField] private AudioSource fullAudio;
    [SerializeField] private List<AudioSource> clickAudio;
    
    public void click(int gobletID){
        clickAudio[correctOrder[gobletID]].Play(0);
        //user already got gem
        if(correctCount > 6){
            return;
        }

        //check if tapping in correct order
        if(correctOrder[correctCount] == gobletID){
            correctCount++;
            if(correctCount == 6){
                Debug.Log("You win!");

                Item gem = GameManager.instance.itemManager.GetItemByName("Purple Gem");
                GameManager.instance.player.DropItem(gem); //drop gem
                GameManager.instance.uiManager.ToggleGobletStand(); //close goblet stand
            }
        }
        else{
            correctCount = 0;
        }

        return;
    }

    public void showGobletStand(){
        Debug.Log("Show goblet stand running");
        GameManager.instance.uiManager.ToggleGobletStand();
        return;
    }

    public void playFullAudio(){
        Debug.Log("playing full audio");
        fullAudio.Play(0);
    }
}
