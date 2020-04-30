using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holdable : Interactable {

    public int score;
    private PlayerController pc;
    private bool onGround = false;
    private Rigidbody rb;
    public bool isSafe, isContainer;
    public List<Reagent> contents;
    
    void Awake() {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.constraints = RigidbodyConstraints.FreezeAll;

    }
    public override void Interact() {
        //transform.localScale = Vector3.one;
        if (onGround) {
            transform.parent = player;
            pc = transform.parent.GetComponent<PlayerController>();
            pc.child = this;
            onGround = false;
            rb.constraints = RigidbodyConstraints.FreezeAll;
            transform.rotation = Quaternion.identity;
            StartCoroutine(ReturnToHand((player.forward * .8f) + player.position, 0.5f));

        } else {
            pc = transform.parent.GetComponent<PlayerController>();
            transform.parent = null;
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