using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour {

    [SerializeField] Vector3 vector;
    Rigidbody2D myRigidbody;
    private bool isThrowable = false;

    private void Start() {
        myRigidbody = GetComponent<Rigidbody2D>();
        myRigidbody.bodyType = RigidbodyType2D.Kinematic;
    }

    private void Update() {
        throwJelly();
    }

    private void throwJelly() {
        if (Input.GetKeyDown(KeyCode.Space) && IsThrowable == false) {
            myRigidbody.bodyType = RigidbodyType2D.Dynamic;
            myRigidbody.velocity = vector;    
            IsThrowable = true;
        }
    }

    public bool IsThrowable {
        get {
            return isThrowable;
        } set {
            isThrowable = value;
        }
    } 
}
