using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashStation : Interactable {

    public override void Interact() {
        if (player.childCount > 0) {
            PlayerController pc = player.GetComponent<PlayerController>();
            Destroy(pc.child.gameObject);
            pc.child = null;
        }
    }
}