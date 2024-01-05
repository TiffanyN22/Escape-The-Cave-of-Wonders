using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HourglassPuzzlePiece : MonoBehaviour
{
    public Image image;
    public Sprite imgSprite;
    public int hourglassId;

    void Start()
    {
        image = GetComponent<Image>();
    }

    public void updateImage(Sprite newImage){
        image.sprite = newImage;
    }

    public void tintImage(bool tint){
        if(tint){
            image.color = new Color32(255, 255, 255, 170);
        } else{
            image.color = new Color32(255, 255, 255, 255);
        }
    }
}
