using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private Sprite fireImg;
    [SerializeField] private Sprite smokeImg;
    [SerializeField] private RuntimeAnimatorController fireAnim;
    [SerializeField] private RuntimeAnimatorController smokeAnim;

    public SpriteRenderer render;
    public Animator animator;

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
            currentState = fireState.smoke; 
            render.color = new Color(255, 255, 255, 255);
            render.sprite = smokeImg;
            animator.runtimeAnimatorController = smokeAnim;
            

            yield return new WaitForSeconds(1);
            currentState = fireState.fire; 
            render.sprite = fireImg;
            animator.runtimeAnimatorController = fireAnim;

            yield return new WaitForSeconds(2);
            currentState = fireState.safe; 
            render.color = new Color(255, 255, 255, 0);
        }
    }
}