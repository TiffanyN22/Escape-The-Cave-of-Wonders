using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampInstructions : MonoBehaviour
{
    [SerializeField] private GameObject lampClue;
    void OnMouseDown()
    {
        Debug.Log("lamp on mouse down");
        lampClue.SetActive(!lampClue.activeSelf);
    }
}
