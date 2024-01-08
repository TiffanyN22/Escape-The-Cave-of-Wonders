using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LampClick : MonoBehaviour
{
    [SerializeField] private AudioSource clickAudio;

    void OnMouseDown(){
        Debug.Log("playing full audio with mouse down");
        clickAudio.Play(0);
    }
}
