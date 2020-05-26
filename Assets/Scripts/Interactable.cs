using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {
    public Transform interactionTransform;
    protected bool isFocused = false, hasInteracted = false;
    protected Transform player;

    public List<Action> actions;
    
    public virtual void Interact() {
        //This method is meant to be overwritten
        Debug.Log("Interact with " + interactionTransform.name);
    }


    public void OnFocused(Transform playerTransform) {
        isFocused = true;
        player = playerTransform;
    }

    public void OnDefocused() {
        isFocused = false;
        player = null;
        hasInteracted = false;
    }


    private void Start() {
        if(interactionTransform==null){
            interactionTransform = transform;
        }
    }
}