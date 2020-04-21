using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeItem : MonoBehaviour {

    public Item item;
    private PlayerMovement playerMovement;
    private GameObject instatiated;
    void Start() {
        instatiated = Instantiate(item.prefab,
            new Vector3(transform.position.x + 1f,
            transform.position.y + 1f,
            transform.position.z - 1f),
            Quaternion.identity);
        instatiated.name = item.itemName;
        instatiated.gameObject.transform.parent = gameObject.transform;
        
    }

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Player") && other.transform.childCount == 0) {
            playerMovement = other.GetComponent<PlayerMovement>();
            if (Input.GetButtonDown(playerMovement.fire)) {
                GameObject newItem = Instantiate(instatiated,
                    new Vector3(other.transform.position.x, other.transform.position.y,
                        other.transform.position.z + 1f), Quaternion.identity);
                newItem.transform.parent = other.transform;

            }
        }
    }
}