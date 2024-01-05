using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawWithMouse : MonoBehaviour
{
    [SerializeField] UILineRenderer line;
    private Vector2 previousPosition;
    [SerializeField] float minDistance;
    private Vector2 center;

    private void Start(){
        previousPosition = transform.position;
    }

    private void Update()
    {
        if(Input.GetMouseButton(0)){
            Debug.Log("Drawing");
            Vector2 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("Current Position" + currentPosition);
            
            Vector2 drawPos = new Vector2((currentPosition.x * 32f), (currentPosition.y * 30.85f -5.24f));

            if(Vector2.Distance(currentPosition, previousPosition) > minDistance){
                line.points.Add(drawPos);
                line.SetAllDirty();
                previousPosition = currentPosition;
            }
        }
    }
}
