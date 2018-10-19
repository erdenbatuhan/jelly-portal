using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour {

    /* Global Variables */
    [SerializeField] Vector2 velocityVector;
    private bool isThrowable = true;

    /* Cached Variables */
    Rigidbody2D myRigidbody;

    private void Start() {
        myRigidbody = GetComponent<Rigidbody2D>();
        myRigidbody.bodyType = RigidbodyType2D.Kinematic;
    }

    private void Update() {
        if (isThrowable && Input.GetKeyDown(KeyCode.Space))
            throwJelly();
    }

    private void throwJelly() {
        myRigidbody.bodyType = RigidbodyType2D.Dynamic;
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
