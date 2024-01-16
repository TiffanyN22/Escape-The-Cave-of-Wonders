using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverPuzzle : MonoBehaviour
{

    public List<Transform> riverIcons = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void click(int clickIndex){
        riverIcons[clickIndex].Rotate(0,0,90);
        if(checkWin()){
            Debug.Log("Win!");
        }
    }

    private bool checkWin(){
        for(int i = 0; i < riverIcons.Count; i++){
            if(riverIcons[i].transform.rotation.z != 0){
                return false;
            }
        }
        return true;
    }
}
