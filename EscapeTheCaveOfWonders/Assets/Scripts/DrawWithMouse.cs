using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Radishmouse;

public class DrawWithMouse : MonoBehaviour
{
    [SerializeField] UILineRenderer line;
    private Vector2 previousPosition;
    [SerializeField] float minDistance;
    private Vector2 center;

    private void Start(){
        // line = GetComponent<LineRenderer>();
        previousPosition = transform.position;
    }

    private void Update()
    {
        if(Input.GetMouseButton(0)){
            Debug.Log("Drawing");
            Vector2 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Vector2 drawPos = new Vector2((currentPosition.x * 119.08f + 413f), (currentPosition.y * -35.5f + 262f));
            Debug.Log("Current Position" + currentPosition);
            

            //based on center
            // Vector2 panelCenter = transform.position;
            // Debug.Log("Center position: " + panelCenter);
            // Debug.Log("Dist from center: " + (currentPosition - panelCenter));
            // Vector2 drawPos = new Vector2((currentPosition.x * 32f + 13224.64f), (currentPosition.y * 31.75f + 8308.57f));

             Vector2 drawPos = new Vector2((currentPosition.x * 32f), (currentPosition.y * 30.85f -5.24f));

            if(Vector2.Distance(currentPosition, previousPosition) > minDistance){
                // line.points = line.points.Append(currentPosition).ToArray();
                line.points.Add(drawPos);
                line.SetAllDirty();
                previousPosition = currentPosition;
            }
        }
    }
}
