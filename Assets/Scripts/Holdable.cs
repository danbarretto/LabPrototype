using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holdable : Interactable {

    private string playerFire = "";
    private GameObject item;
    private bool isHolding = false;
    override public void Interact() {
        Debug.Log("Holding");
        if (player.childCount == 0) {
            GameObject newHoldable = Instantiate(interactionTransform.parent.gameObject, new Vector3(
                player.position.x,
                player.position.y,
                player.position.z + 1
            ), Quaternion.identity);
            newHoldable.transform.parent = player;
            item = newHoldable;
            isHolding = true;
        }
    }

    private void Update() {
        if (!isInteracting && isHolding && Input.GetButtonDown("Fire1") && GameObject.Find("Player1").transform == player) {
            item.transform.parent = null;
            item = null;
            isHolding = false;
            OnDefocused();;
        }
    }

}