using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChessPuzzle : MonoBehaviour
{
    public List<ChessPiece> allChessPieces = new List<ChessPiece>();
    public List<Sprite> allSprites = new List<Sprite>();
    private int firstSelectIndex = -1;
     private int redIndex = -1;
    // first they click 15, then 7
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("chess puzzle started");
    }

    public void click(int clickedIndex){
        Debug.Log("CLICK!");
        if (firstSelectIndex == -1){
            Debug.Log("CLICKED 1st");
            if(redIndex!= -1)
            {
                Debug.Log("cleared red from before");
                allChessPieces[redIndex].GetComponent<Image>().color = new Color(255, 255, 255, 255);
                Debug.Log("previous red cleared");
            }
            firstSelectIndex = clickedIndex;
            Debug.Log("1st click should shade green");
            allChessPieces[clickedIndex].GetComponent<Image>().color = new Color(0, 255, 146, 255);
            //Debug.Log("1st click should be shaded");
        } 
        else
        {
            if (firstSelectIndex == 14 && clickedIndex == 6)
            {
                Debug.Log("CORRECT! 2nd click -> 1st should dissapear and 2nd should appear");
                allChessPieces[firstSelectIndex].GetComponent<Image>().color = new Color(255, 255, 255, 0);
                allChessPieces[clickedIndex].GetComponent<Image>().color = new Color(255, 255, 255, 255);

                //GameManager.instance.uiManager.ToggleHourglassRearrangePanel();
            }
            else
            {
                Debug.Log("1st item clicked is red shade");
                allChessPieces[firstSelectIndex].GetComponent<Image>().color = new Color(255, 0, 0, 255);
                redIndex = firstSelectIndex;
            }

            firstSelectIndex = -1;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
