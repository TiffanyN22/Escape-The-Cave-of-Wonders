using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaultPuzzle : MonoBehaviour
{
    [SerializeField] Transform dial1;
    [SerializeField] Transform dial2;
    private float dial1Target = -0.539f;
    private float dial2Target = 0.715f;

    void Update()
    {
        if(closeToAngle(dial1.rotation.z, dial1Target) && closeToAngle(dial2.rotation.z, dial2Target)){
            Debug.Log("dial success!");
        }
    }

    private bool closeToAngle(float dialAngle, float targetAngle){
        return Mathf.Abs(dialAngle-targetAngle) < 0.1;
    }
}
