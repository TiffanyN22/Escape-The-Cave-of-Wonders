using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using UnityEngine.EventSystems;

public class HourglassPuzzlePiece : MonoBehaviour
{
    public Image image; 
    // public Sprite newImage;

    void Start()
    {
        image = GetComponent<Image>();
    }

    // public void updateImage(){
    //     image.color = new Color32(255, 255, 255, 170);
    // }
    public void updateImage(Sprite newImage){
        image.sprite = newImage;
        // image.color = new Color32(255, 255, 255, 255);
    }
}
