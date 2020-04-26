using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashStation : Interactable {

    public override void Interact(){
        if(player.childCount > 0f){
            Destroy(player.GetChild(0).gameObject);
        }
    }
}