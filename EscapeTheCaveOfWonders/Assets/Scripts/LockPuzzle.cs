using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LockPuzzle : MonoBehaviour
{
    [SerializeField] private TreasureChest chest;
    [SerializeField] private List<TextMeshProUGUI> lockSelection = new List<TextMeshProUGUI>();
    private string[] correctOrder = {"B", "2", "B", "1"};

    public void click(int clickIndex){
        switch(clickIndex){
            case 0:
            case 2:
                char[] letter = lockSelection[clickIndex].text.ToCharArray();
                if(letter[0] == 'H'){
                    lockSelection[clickIndex].text = "A";
                } else{
                    lockSelection[clickIndex].text = (++letter[0]).ToString();
                }
                break;
            case 4:
            case 6:
                char[] letter2 = lockSelection[clickIndex - 4].text.ToCharArray();
                if(letter2[0] == 'A'){
                    lockSelection[clickIndex - 4].text = "H";
                } else{
                    lockSelection[clickIndex - 4].text = (--letter2[0]).ToString();
                }
                break;
            case 1:
            case 3:
                int curValue = int.Parse(lockSelection[clickIndex].text);
                if(curValue == 8){
                    lockSelection[clickIndex].text = "1";
                } else{
                    lockSelection[clickIndex].text = (curValue + 1).ToString();
                }
                break;
            case 5:
            case 7:
                int curValue2 = int.Parse(lockSelection[clickIndex - 4].text);
                if(curValue2 == 1){
                    lockSelection[clickIndex - 4].text = "8";
                } else{
                    lockSelection[clickIndex - 4].text = (curValue2 - 1).ToString();
                }
                break;
        }

        if(checkWin()){
            GameManager.instance.uiManager.ToggleLockPuzzlePanel();
            chest.DropKey();
        }
    }

    private bool checkWin(){
        for(int i = 0; i < lockSelection.Count; i++){
            if(lockSelection[i].text != correctOrder[i]){
                return false;
            }
        }
        return true;
    }
}
