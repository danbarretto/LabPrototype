using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private string xAxis, zAxis, fire, fire2;

    public float speed = 20f, interactionRadius = 3f;
    public bool isInZone = false;
    private Rigidbody rigidBody;
    public Interactable focus;
    public Interactable child;
    [System.Serializable]
    public enum Player {
        Player1,
        Player2
    }

    public Player playerNum;

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
    private void Start() {
        rigidBody = GetComponent<Rigidbody>();
        if (playerNum == Player.Player1) {
            xAxis = GameManager.instace.Horizontal_P1;
            zAxis = GameManager.instace.Vertical_P1;
            fire = GameManager.instace.Fire1_P1;
            fire2 = GameManager.instace.Fire2_P1;
        } else {
            xAxis = GameManager.instace.Horizontal_P2;
            zAxis = GameManager.instace.Vertical_P2;
            fire = GameManager.instace.Fire1_P2;
            fire2 = GameManager.instace.Fire2_P2;
        }
    }
    void Update() {
        float moveHorizontal = Input.GetAxis(xAxis);
        float moveVertical = Input.GetAxis(zAxis);
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        if (movement != Vector3.zero) {
            transform.rotation = Quaternion.LookRotation(movement);
        }

        rigidBody.velocity = new Vector3(moveHorizontal * speed, 0f, moveVertical * speed);

        if (Input.GetButtonDown(fire)) {
            if(focus !=null && isInZone){
                focus.Interact();
            }else if(!isInZone && child!=focus){
                child.Interact();
            }
        }

    }

    public string getFire() {
        return fire;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Interactable")) {
            isInZone = true;
            Interactable interactable = other.GetComponent<Interactable>();
            if (interactable != null) {
                SetFocus(interactable);
            }
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Interactable")) {
            isInZone = false;
        }
    }

    public void SetFocus(Interactable newFocus) {
        if (newFocus != focus) {
            if (focus != null)
                focus.OnDefocused();
            focus = newFocus;
        }
        newFocus.OnFocused(transform);
    }

    public void RemoveFocus() {
        if (focus != null)
            focus.OnDefocused();
        focus = null;

    }

}