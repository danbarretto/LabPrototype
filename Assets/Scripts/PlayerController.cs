using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private string xAxis, zAxis, fire, fire2;

    public float speed = 20f;
    public float interactionDistance = 2.5f;
    public Transform hands;
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

        RaycastHit objectHit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        Debug.DrawRay(transform.position, fwd * interactionDistance, Color.green);
        if (Physics.Raycast(transform.position, fwd, out objectHit, Mathf.Infinity)) {
        if (objectHit.collider.gameObject.CompareTag("Interactable") &&
            Vector3.Distance(objectHit.transform.position, transform.position) < interactionDistance) {
            SetFocus(objectHit.collider.GetComponent<Interactable>());
        } else {
            RemoveFocus();
        }
    }

    if (Input.GetButtonDown(fire2) && focus && !(focus is Holdable || focus is Station)) {
        focus.Interact();
    }
    if (Input.GetButtonDown(fire)) {
        PickUp();
    }
}

private void PickUp() {
    if (!focus && child && child is Holdable) {
        child.Interact();
    } else if (focus) {
        if (focus is Holdable) {
            Holdable obj = (Holdable)focus;
            if (obj.isSafe) {
                obj.Interact();
            }
        } else if (focus is Station) {
            focus.Interact();
        }
    }
}
public string getFire() {
    return fire;
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