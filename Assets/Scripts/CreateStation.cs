using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStation : Station {

    private Item itemToCreate;
    public override void Interact() {
        if (itemToCreate.isSafe && !player.GetComponentInChildren<Experiment>()) {
            CreateItem(player);
        } else if (!itemToCreate.isSafe) {
            Holdable container = (Holdable)player.GetComponent<PlayerController>().child;
            if (container && container.isSafe && container.isContainer && !container.actions.Contains(stationAction)) {
                container.GetComponent<MeshRenderer>().material = itemToCreate.fillContainerMaterial;
                base.Interact();
                
            }
        }
    }
    private void Start() {
        itemToCreate = stationAction.items[0];
        Vector3 parentPos = new Vector3(
            transform.position.x + 1,
            transform.position.y + 1,
            transform.position.z - 1);
        GameObject objectView = Instantiate(itemToCreate.model, parentPos, Quaternion.identity);
        objectView.transform.parent = transform;
    }

    private void CreateItem(Transform parentTransform) {
        PlayerController pc = player.GetComponent<PlayerController>();
        GameObject experiment = new GameObject("Experiment");
        experiment.AddComponent<Experiment>();
        experiment.transform.parent = parentTransform;
        Experiment exp = experiment.GetComponent<Experiment>();

        GameObject newHoldable = Instantiate(itemToCreate.model, (player.forward * .8f) + player.position, Quaternion.identity);
        exp.parentInteractable = newHoldable.GetComponent<Interactable>();
        exp.actions.Add(stationAction);
        //Ignores Raycast when in hands
        newHoldable.layer = 2;
        newHoldable.transform.parent = experiment.transform;
        newHoldable.transform.localScale = Vector3.one;

        newHoldable.GetComponent<Holdable>().isSafe = itemToCreate.isSafe;
        newHoldable.GetComponent<Holdable>().isContainer = itemToCreate.isContainer;
        pc.RemoveFocus();
        if (pc.child == null)
            pc.child = newHoldable.GetComponent<Interactable>();
    }
}