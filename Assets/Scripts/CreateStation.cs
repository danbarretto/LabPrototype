using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStation : Interactable {

    public Item itemToCreate;
    public override void Interact() {
        if (player.childCount == 0) {
            PlayerController pc = player.GetComponent<PlayerController>();
            GameObject newHoldable = Instantiate(itemToCreate.model, new Vector3(
                player.position.x,
                player.position.y,
                player.position.z + 1
            ), Quaternion.identity);
            newHoldable.transform.parent = player;
            newHoldable.GetComponent<Holdable>().score = itemToCreate.score;
            pc.RemoveFocus();
            pc.child = newHoldable.GetComponent<Interactable>();
        }
    }
    private void Start() {
        Vector3 parentPos = new Vector3(
            transform.position.x + 1,
            transform.position.y + 1,
            transform.position.z - 1);
        GameObject objectView = Instantiate(itemToCreate.model, parentPos, Quaternion.identity);
        objectView.transform.parent = transform;
        Destroy(objectView.GetComponent<Holdable>());
    }

}