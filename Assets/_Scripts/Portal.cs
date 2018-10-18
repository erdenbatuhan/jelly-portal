using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Extensions;

public class Portal : MonoBehaviour {
    [SerializeField] Jelly jelly;
    [SerializeField] Portal destination;
    Transform jellyTransform;
    Transform destinationTransform;
    Rigidbody2D jellyRigidbody;

    public void Start() { 
        jellyTransform = jelly.GetComponent<Transform>();
        destinationTransform = destination.GetComponent<Transform>();
        jellyRigidbody = jelly.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Jelly>() != null)
        {
            Vector2 enteringVelocity = jellyRigidbody.velocity;

            jellyTransform.position = destinationTransform.position;   // teleport the jelly
            float beta = transform.eulerAngles.z + destination.transform.eulerAngles.z;     // rotate the velocity vector beta degrees

            jelly.GetComponent<Rigidbody2D>().velocity = Vector2Extension.Rotate(enteringVelocity, beta);
        }
    }
}
