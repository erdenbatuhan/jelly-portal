using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour {

    private bool isReleased = false;
    /* Cached Variables */
    Rigidbody2D rigidbody;
    VirtualJelly virtualJelly;

    private void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
        GetComponent<BoxCollider2D>().enabled = false;
        virtualJelly = FindObjectOfType<VirtualJelly>();
        rigidbody.isKinematic = true;
    }

    public void throwJelly() {
        rigidbody.velocity = virtualJelly.VelocityVector;
    }

    public bool IsReleased {
        get {
            return isReleased;
        } set {
            isReleased = value;
        }
    }
}
