using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChessPiece : MonoBehaviour
{
    public Image image;
    public Sprite imgSprite;
    public int hi;
    bool showImage;
    public bool black;
    // Start is called before the first frame update
    void Start()
    {
        // image = GetComponent<Image>();
    }

    public bool isBlack(){
        return black;
    }
    public void updateImage(){
     }

    // Update is called once per frame
    void Update()
    {
        
    }
}
