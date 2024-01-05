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

    // public void updatePuzzlePiece(HourglassPuzzlePiece newPiece){
    //     Debug.Log("update puzzle piece running");
    //     Debug.Log("this" + hourglassId);
    //     Debug.Log("new"+newPiece.hourglassId);

    //     image = newPiece.image;
    //     image.sprite = newPiece.imgSprite;
    //     imgSprite = newPiece.imgSprite;
    //     hourglassId = newPiece.hourglassId; 
    // }

    public void tintImage(bool tint){
        if(tint){
            image.color = new Color32(255, 255, 255, 170);
        } else{
            image.color = new Color32(255, 255, 255, 255);
        }
    }

    // public HourglassPuzzlePiece returnPieceInfo(){
    //     return new HourglassPuzzlePiece {
    //         image = image,
    //         hourglassId = hourglassId,
    //     };
    // }
}
