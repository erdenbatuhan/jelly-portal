using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour {

    /* Global Variables */
    [SerializeField] Vector2 velocityVector;
    private bool isThrowable = true;
    private bool isPressed = false;
    /* Cached Variables */
    Rigidbody2D myRigidbody;
    Vector2 throwVector;

    private void Start() {
        myRigidbody = GetComponent<Rigidbody2D>();
        GetComponent<BoxCollider2D>().enabled = false;
        myRigidbody.isKinematic = true;
    }

    private void Update() {
        if (isThrowable && Input.GetKeyDown(KeyCode.Space))
            throwJelly();
    }

    private void throwJelly() {
        myRigidbody.velocity = velocityVector; 
        isThrowable = false;
    }

    public bool IsThrowable {
        get {
            return isThrowable;
        } set {
            isThrowable = value;
        }
    }
}
