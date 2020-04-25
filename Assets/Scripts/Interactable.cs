using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {
    public float radius = 3f;
    public Transform interactionTransform;
    protected bool isFocused = false, hasInteracted=false;
    public bool isInteracting = false;
    protected Transform player;


    public virtual void Interact(){
        //This method is meant to be overwritten
        Debug.Log("Interact with "+ interactionTransform.name);
    }

    private void Update() {
        if(isFocused && !hasInteracted){
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if(distance <= radius){
                Interact();
                hasInteracted = true;
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);    
    }

    public void OnFocused(Transform playerTransform){
        isFocused = true;
        player = playerTransform;
    }

    public void OnDefocused(){
        isFocused = false;
        player = null;
        hasInteracted = false;
    }
}