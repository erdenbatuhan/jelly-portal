using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour {

    /* Global Variables */
    [SerializeField] Vector2 velocityVector;
    private bool isThrowable = true;
    private bool isPressed = false;
    private const float releaseTime = 0.15f;
    /* Cached Variables */
    Rigidbody2D myRigidbody;

    private void Start() {
        myRigidbody = GetComponent<Rigidbody2D>();
        myRigidbody.bodyType = RigidbodyType2D.Kinematic;
    }

    private void Update() {
        if (isThrowable && Input.GetKeyDown(KeyCode.Space))
            throwJelly(velocityVector);
        if (isPressed) {
            myRigidbody.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void OnMouseDown() {
        isPressed = true;
        myRigidbody.isKinematic = true;
    }

    private void OnMouseUp() {
        isPressed = false;
        myRigidbody.isKinematic = false;
        StartCoroutine(Release());
    }

    private IEnumerator Release() {
        yield return new WaitForSeconds(releaseTime);
        GetComponent<SpringJoint2D>().enabled = false;
    }

    private void throwJelly(Vector2 vector) {
        myRigidbody.bodyType = RigidbodyType2D.Dynamic;
        myRigidbody.velocity = vector; 

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
