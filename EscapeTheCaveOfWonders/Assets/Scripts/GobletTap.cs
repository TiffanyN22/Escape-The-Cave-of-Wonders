using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GobletTap : MonoBehaviour
{
    private int[] correctOrder = { 3, 0, 2, 5, 1, 4 };
    private int correctCount = 0;
    
    public void click(int gobletID){
        // TODO: play sound on click

        if(correctOrder[correctCount] == gobletID){
            correctCount++;
            if(correctCount == 6){
                Debug.Log("You win!");
                correctCount = 0;
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
}
