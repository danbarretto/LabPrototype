using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : Interactable {

    public GameObject item;


    public override void Interact(){
        PlayerController pc = player.GetComponent<PlayerController>();
        if(!item && pc.child){
            item = player.GetComponentInChildren<Experiment>().gameObject;
            item.transform.SetParent(transform);
            item.transform.position = transform.position + new Vector3(1,1,-1);
            pc.child.transform.position = transform.position + new Vector3(1,1,-1);
            pc.child = null;
        }else if(!pc.child && item){

            item.transform.SetParent(player);
            pc.child = item.GetComponent<Experiment>().parentInteractable;
            item.transform.position = pc.hands.position;
            pc.child.transform.position = pc.hands.position;
            item = null;
        }
    }
}