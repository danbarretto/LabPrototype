using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holdable : Interactable {

    public int score;

    public override void Interact() {
        if (player.childCount == 0) {

            transform.parent = player;
            gameObject.tag = "Item";
            player.GetComponent<PlayerController>().RemoveFocus();

        }

    }

   
    

}