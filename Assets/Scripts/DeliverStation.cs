using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DeliverStation : Interactable {

    public Text scoreText;
    public override void Interact() {
        if (player.childCount > 0) {

            Holdable hold = player.GetChild(0).GetComponent<Holdable>();
            if (hold != null) {
                GameManager.instace.score += hold.score/3;
                scoreText.text = "Score: " + GameManager.instace.score;
                Destroy(hold.gameObject);

            }
        }
    }
}