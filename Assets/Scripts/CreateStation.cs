using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStation : Interactable {

    public Item itemToCreate;

    public override void Interact() {
        if (player.childCount == 0 && itemToCreate.isSafe) {
            CreateItem(player);
        } else if (!itemToCreate.isSafe) {
            Holdable container = (Holdable)player.GetComponent<PlayerController>().child;
            if (container && container.isSafe && container.isContainer) {
                container.GetComponent<MeshRenderer>().material = itemToCreate.fillContainerMaterial;
                container.contents.Add(itemToCreate.reagent);
                container.score += itemToCreate.score;
            }
        }
    }
    private void Start() {
        Vector3 parentPos = new Vector3(
            transform.position.x + 1,
            transform.position.y + 1,
            transform.position.z - 1);
        GameObject objectView = Instantiate(itemToCreate.model, parentPos, Quaternion.identity);
        objectView.transform.parent = transform;
    }

    private void CreateItem(Transform parentTransform) {
        PlayerController pc = player.GetComponent<PlayerController>();
        GameObject newHoldable = Instantiate(itemToCreate.model, (player.forward * .8f) + player.position, Quaternion.identity);
        newHoldable.transform.parent = parentTransform;
        newHoldable.transform.localScale = Vector3.one;

        newHoldable.GetComponent<Holdable>().score = itemToCreate.score;
        newHoldable.GetComponent<Holdable>().isSafe = itemToCreate.isSafe;
        newHoldable.GetComponent<Holdable>().isContainer = itemToCreate.isContainer;
        pc.RemoveFocus();
        if (pc.child == null)
            pc.child = newHoldable.GetComponent<Interactable>();
    }
}