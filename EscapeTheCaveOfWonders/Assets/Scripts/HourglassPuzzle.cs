using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class HourglassPuzzle : MonoBehaviour
{
    private int blankSpaceIndex = 11;
    public List<HourglassPuzzlePiece> allPuzzlePeices = new List<HourglassPuzzlePiece>();
    public Sprite blankImage;

    public void click(int clickedIndex){
        if (allPuzzlePeices == null){
            Debug.Log("allPuzzlePeices is null");
            return;
        }

        allPuzzlePeices[blankSpaceIndex].updateImage(allPuzzlePeices[clickedIndex].image.sprite);
        allPuzzlePeices[clickedIndex].updateImage(blankImage);
        blankSpaceIndex = clickedIndex;
    }
}
