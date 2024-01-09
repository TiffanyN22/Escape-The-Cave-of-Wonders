using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaultPuzzle : MonoBehaviour
{
    [SerializeField] Transform dial1;
    [SerializeField] Transform dial2;
    private float dial1Target = 0.8765f;
    private float dial2Target = -0.708f;
    private bool droppedGem = false;

    void Update()
    {
        if(droppedGem){
            return;
        }
        if(closeToAngle(dial1.rotation.z, dial1Target) && closeToAngle(dial2.rotation.z, dial2Target)){
            Debug.Log("dial success!");
            DropGem();
        }
    }

    private bool closeToAngle(float dialAngle, float targetAngle){
        // Debug.Log(dialAngle);
        return Mathf.Abs(dialAngle-targetAngle) < 0.1;
    }

    private void DropGem()
    {
        Item gem = GameManager.instance.itemManager.GetItemByName("Red Gem");
        Vector2 spawnLocation = transform.position;
        Vector2 spawnOffset = new Vector2(1f, Random.Range(-1f, 0f));

        Item droppedItem = Instantiate(gem, spawnLocation + spawnOffset, 
            Quaternion.identity);
        droppedItem.rb2d.AddForce(spawnOffset * 1f, ForceMode2D.Impulse);
        droppedGem = true;
   }
}
