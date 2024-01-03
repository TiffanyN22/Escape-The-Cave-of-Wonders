using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GobletTap : MonoBehaviour
{
    int[] correctOrder = { 3, 0, 2, 5, 1, 4 };
    // int[] clickOrder = new int[6];
    int correctCount = 0;
    
    public void click(int gobletID){
        // clickOrder[correctCount] = gobletID;

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
}
