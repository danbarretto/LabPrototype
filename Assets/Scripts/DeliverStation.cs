﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DeliverStation : Interactable {

    public Text scoreText;
    public override void Interact() {
        if (player.childCount > 0) {

            Holdable hold = player.GetChild(0).GetComponent<Holdable>();
            if (hold != null) {
                scoreText.text = "Score: " + GameManager.instace.score;
                player.GetComponent<PlayerController>().child = null;
                Destroy(hold.gameObject);
            }
        }
    }

    private void Start() {
        scoreText.text = "Score: 0";
    }
}