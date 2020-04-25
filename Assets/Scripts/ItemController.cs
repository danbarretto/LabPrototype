using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : Interactable {


   
    override public void Interact() {
        GameObject newItem = Instantiate(gameObject,
            new Vector3(player.position.x, player.position.y,
                player.position.z + 1f), Quaternion.identity);
        newItem.transform.parent = player;
    }

}