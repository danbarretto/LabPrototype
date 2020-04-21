using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    // Start is called before the first frame update
    public string xAxis, zAxis, fire;

    public float speed = 20f;
    private Rigidbody rigidBody;

    // Update is called once per frame
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

        if(Input.GetButtonDown(fire)){
            Debug.Log("Ação");
        }

    }
}