using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawWithMouse : MonoBehaviour
{
    [SerializeField] UILineRenderer line;
    private Vector2 previousPosition;
    [SerializeField] float minDistance;
    private Vector2 center;
    public List<Vector2> treasurePoints = new List<Vector2>();
    public List<bool> foundTreasureList = new List<bool>();

    private void Start(){
        treasurePoints.Add(new Vector2(-1.49f, -1.78f));
        treasurePoints.Add(new Vector2(-0.58f, 0.04f));
        treasurePoints.Add(new Vector2(1.56f, 0.75f));
        treasurePoints.Add(new Vector2(1.65f, -1.04f));

        for(int i = 0; i < treasurePoints.Count; i++){
            foundTreasureList.Add(false);
        }
        previousPosition = transform.position;
        Debug.Log("treasure point" + treasurePoints[0]);
    }

    private void Update()
    {
        if(Input.GetMouseButton(0)){
            Vector2 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("Current Position" + currentPosition);
            
            Vector2 drawPos = new Vector2((currentPosition.x * 32f), (currentPosition.y * 30.85f -5.24f));

            if(checkTreasures(currentPosition)){
                Debug.Log("Winner!!!!");
            }
            if(Vector2.Distance(currentPosition, previousPosition) > minDistance){
                line.points.Add(drawPos);
                line.SetAllDirty();
                previousPosition = currentPosition;
            }
        }
    }

    private bool foundTreasure(Vector2 curPos, Vector2 treasurePos){
        //close enough --> consider to draw over
        return (Mathf.Abs(curPos.x - treasurePos.x) < 0.25) && (Mathf.Abs(curPos.y - treasurePos.y) < 0.25);
    }

    private bool checkTreasures(Vector2 curPos){
        for(int i = 0; i < treasurePoints.Count; i++){
            if(!foundTreasureList[i] && foundTreasure(curPos, treasurePoints[i])){
                foundTreasureList[i] = true;
                if(foundAllTreasures()){
                    return true;
                }
            }
        }
        return false;
    }

    private bool foundAllTreasures(){
        for(int i = 0; i < treasurePoints.Count; i++){
            if(!foundTreasureList[i]){
                return false;
            }
        }
        return true;
    }
}
