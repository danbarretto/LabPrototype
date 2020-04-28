using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holdable : Interactable {

    public int score;
    private PlayerController pc;
    private bool onGround = false;
    public override void Interact() {
        if (onGround) {
            transform.parent = player;
            pc = transform.parent.GetComponent<PlayerController>();
            pc.child = this;
            onGround = false;
        } else {
            pc = transform.parent.GetComponent<PlayerController>();
            transform.parent = null;
            pc.child = null;
            onGround = true;
        }

    }

}