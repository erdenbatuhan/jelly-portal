using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour {
    [SerializeField] Vector3 vector;
     Rigidbody myRigidbody;
    private bool isPressedSpace = false;

    private void Start() {
        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.useGravity = false;
    }

    private void Update() {
        throwJelly();
    }

    private void throwJelly() {
        if (Input.GetKeyDown(KeyCode.Space) && isPressedSpace == false) {
            myRigidbody.useGravity = true;
            myRigidbody.velocity = vector;
            isPressedSpace = true;
        }
    }
}
