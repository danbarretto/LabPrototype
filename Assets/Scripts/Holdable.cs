using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holdable : Interactable {

    public int score;
    private PlayerController pc;
    private bool onGround = false;
    private Rigidbody rb;
    void Awake() {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
    public override void Interact() {
        if (onGround) {
            transform.parent = player;
            pc = transform.parent.GetComponent<PlayerController>();
            pc.child = this;
            onGround = false;
            rb.constraints = RigidbodyConstraints.FreezeAll;
            transform.rotation = Quaternion.identity;
            StartCoroutine(ReturnToHand(new Vector3(
                player.position.x,
                player.position.y,
                player.position.z + 1), 0.5f));

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
        while(t<moveDuration){
            t+= Time.deltaTime;
            transform.position = Vector3.Slerp(transform.position, playerPos, t/moveDuration);
            yield return null;
        }
    }

}