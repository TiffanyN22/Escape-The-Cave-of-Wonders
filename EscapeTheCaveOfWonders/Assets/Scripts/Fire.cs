using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private Sprite fireImg;
    [SerializeField] private Sprite smokeImg;
    public Animator animator;

    public SpriteRenderer render;
    // public Animator animator;

    public enum fireState{safe, smoke, fire}
    public fireState currentState = fireState.safe;

    private void Start(){
        render = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        StartCoroutine(fireCoroutine());
    }

    private void OnTriggerStay2D(Collider2D other){
        if (other.gameObject.tag == "Player" && currentState == fireState.fire)
        {
            GameManager.instance.player.Respawn();
            // Debug.Log("player walked into fire");
        }
    }

    IEnumerator fireCoroutine()
    {
        while(true){
            yield return new WaitForSeconds(3);
            animator.SetInteger("State", 1);
            currentState = fireState.smoke; 
            render.sprite = smokeImg;
            
            yield return new WaitForSeconds(1.5f);
            animator.SetInteger("State", 2);
            render.sprite = fireImg;
            currentState = fireState.fire; 
            

            yield return new WaitForSeconds(3);
            animator.SetInteger("State", 0);
            currentState = fireState.safe; 
        }
    }
}
