using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public string xAxis, zAxis, fire, fire2;

    public float speed = 20f, interactionRadius = 3f;
    private Rigidbody rigidBody;
    public Interactable focus;

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
    private void Start() {
        rigidBody = GetComponent<Rigidbody>();
    }
    void Update() {
        float moveHorizontal = Input.GetAxis(xAxis);
        float moveVertical = Input.GetAxis(zAxis);
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        if (movement != Vector3.zero) {
            transform.rotation = Quaternion.LookRotation(movement);
        }

        rigidBody.velocity = new Vector3(moveHorizontal * speed, 0f, moveVertical * speed);

    }

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Interactable")) {

            Interactable interactable = other.GetComponent<Interactable>();
            if (interactable != null) {
                interactable.isInteracting = true;
                if (Input.GetButtonDown(fire)) {
                    SetFocus(interactable);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Interactable")) {
            Interactable interactable = other.GetComponent<Interactable>();
            if (interactable != null) {
                interactable.isInteracting = false;
            }
        }
    }

    void SetFocus(Interactable newFocus) {
        if (newFocus != focus) {
            if (focus != null)
                focus.OnDefocused();
            focus = newFocus;
        }
        newFocus.OnFocused(transform);
    }

    void RemoveFocus() {
        if (focus != null)
            focus.OnDefocused();
        focus = null;
    }

}