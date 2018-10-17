using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    private void OnCollisionEnter(Collision collision) {
        GameObject collider = collision.gameObject;

        if (collider.GetComponent<Jelly>() != null)
            collider.GetComponent<Rigidbody>().isKinematic = true;

        collider.GetComponent<Rigidbody>().isKinematic = false;
    }
}
