using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holdable : Interactable {

    private PlayerController pc;
    private bool onGround = false;
    private Rigidbody rb;
    public bool isSafe, isContainer;
    
    void Awake() {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        gameObject.layer = 2;

    }
    public override void Interact() {
        //transform.localScale = Vector3.one;
        if (onGround) {
            //Ignores Raycast
            gameObject.layer = 2;
            transform.parent.parent = player;
            pc = transform.parent.GetComponentInParent<PlayerController>();
            pc.child = this;
            onGround = false;
            rb.constraints = RigidbodyConstraints.FreezeAll;
            transform.rotation = Quaternion.identity;
            //StartCoroutine(ReturnToHand(pc.hands.position, 0.5f));
            transform.position = pc.hands.position;
        } else {
            gameObject.layer = 0;
            pc = transform.parent.GetComponentInParent<PlayerController>();
            transform.parent.parent = null;
            pc.child = null;
            onGround = true;
            rb.useGravity = true;
            rb.isKinematic = false;
            rb.constraints = RigidbodyConstraints.None;

        }

    }

    public IEnumerator ReturnToHand(Vector3 playerPos, float moveDuration) {
        float t = 0f;
        while (t < moveDuration) {
            t += Time.deltaTime;
            transform.position = Vector3.Slerp(transform.position, playerPos, t / moveDuration);
            yield return null;
        }
    }

}