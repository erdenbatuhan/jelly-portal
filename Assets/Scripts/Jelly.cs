using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour {

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
        StartCoroutine("enableBoxCollider");
    }
    
    private IEnumerator enableBoxCollider() {
        yield return new WaitForSeconds(0.1f);
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
