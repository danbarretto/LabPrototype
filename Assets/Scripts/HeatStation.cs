using UnityEngine;

public class HeatStation : Station {

    public override void Interact() {
        PlayerController pc = player.GetComponent<PlayerController>();
        if (pc.child) {
            Holdable holdable = (Holdable)pc.child;
            if (holdable) {
                foreach (Reagent reagent in holdable.contents) {
                    if (reagent.canHeat && !reagent.isHeated) {
                        holdable.GetComponent<MeshRenderer>().material = reagent.heatedMaterial;
                        reagent.isHeated = true;
                    }

                }
            }
        }
        base.Interact();
    }
}