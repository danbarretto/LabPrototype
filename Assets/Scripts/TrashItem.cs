using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashItem : MonoBehaviour {

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Player") && Input.GetButtonDown(other.GetComponent<PlayerMovement>().fire)) {
            if (other.transform.childCount > 0) {
                Transform item = other.transform.GetChild(0);
                if (item != null) {
                    Destroy(item.gameObject);
                }
            }
        }
    }
}