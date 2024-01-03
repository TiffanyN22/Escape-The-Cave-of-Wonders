using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//Tutorial: https://youtu.be/xFAT-R2_aXM?si=osk4lzOv0x07D3Va

public class PaperDragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform rectTransform; //to change position
    private Image image; //to change color

    public void OnBeginDrag(PointerEventData eventData)
    {
        //makes image transparent
        image.color = new Color32(255, 255, 255, 170);
        Debug.Log("paper drag and drop: Begin on drag running");
    }
    public void OnDrag(PointerEventData eventData)
    {
        //position change
        //rectTransform.anchoredPosition += eventData.delta;
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Default color
        image.color = new Color(255, 255, 255, 255);
    }

    void Start()
    {
        Debug.Log("Paper drag and drop starts");
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }
}
