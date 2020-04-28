using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashStation : Interactable {

    public override void Interact() {
        if (player.childCount > 0) {
            player.GetComponent<PlayerController>().child = null;
            Destroy(player.GetChild(0).gameObject);
        }
    }
}