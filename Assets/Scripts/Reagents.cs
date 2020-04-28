using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reagents : Holdable {

    public override void Interact() {
        if (isSafe) {
            base.Interact();
        }else{
            Debug.Log("Requires a Container!");
            Holdable container = (Holdable) player.GetComponent<PlayerController>().child;
            if(container!=null && container.isContainer){
                transform.parent = container.transform;
                container.score += score;
            }
        }

    }
}