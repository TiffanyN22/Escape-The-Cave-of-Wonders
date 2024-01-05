using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Credit: connect the dots code from https://youtu.be/a3cs6ybxWdY?si=24pkt7sNMI0X8iqo
public class LineController : MonoBehaviour
{
    private LineRenderer lr;
    public List<Transform> points = new List<Transform>();
    public Transform lastPoints;

    void Awake(){
        lr = GetComponent<LineRenderer>();
    }

    private void makeLine(Transform finalPoint){
        if (lastPoints == null){
            lastPoints = finalPoint;
            points.Add(lastPoints);
        } else{
            points.Add(finalPoint);
            lr.enabled = true;
            SetUpLine();
        }
    }

    private void SetUpLine(){
        int pointLength = points.Count;
        lr.positionCount = pointLength;
        for(int i = 0; i < pointLength; i++){
            lr.SetPosition(i, points[i].position);
        }
    }

    void Update(){
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse clicked");
            
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if(hit.collider != null){
                makeLine(hit.collider.transform);
                print(hit.collider.name);
            }
        }
    }

    public void clickPoint(Transform position){
        Debug.Log("clicked point");
        makeLine(position);
    }
}
