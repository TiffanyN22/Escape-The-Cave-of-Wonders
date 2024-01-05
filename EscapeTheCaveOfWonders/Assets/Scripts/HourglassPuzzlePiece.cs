using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HourglassPuzzlePiece : MonoBehaviour
{
    public Image image; 

    void Start()
    {
        image = GetComponent<Image>();
    }

    public void updateImage(Sprite newImage){
        image.sprite = newImage;
    }
}
