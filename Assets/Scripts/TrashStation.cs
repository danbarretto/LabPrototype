using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashStation : Interactable {

    public override void Interact() {
        PlayerController pc = player.GetComponent<PlayerController>();
        if (pc.child) {
            Destroy(pc.child.transform.parent.gameObject);
            pc.child = null;
        }
    }
}