using UnityEngine;

public class HeatStation : Interactable {

    public override void Interact() {
        PlayerController pc = player.GetComponent<PlayerController>();
        if (pc.child) {
            Holdable holdable = (Holdable)pc.child;
            if (holdable) {
                foreach (Reagent reagent in holdable.contents) {
                    if (reagent.canHeat && !reagent.isHeated) {
                        holdable.score += 50;
                        holdable.GetComponent<MeshRenderer>().material = reagent.heatedMaterial;
                        reagent.isHeated = true;
                    }

                }
            }
        }
    }
}