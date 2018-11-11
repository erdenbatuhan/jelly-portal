using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Extensions;

public class Portal : MonoBehaviour {
    [SerializeField] Jelly jelly;
    [SerializeField] Portal to;
    Transform jellyTransform;
    Transform toTransform;
    Rigidbody2D jellyRigidbody;
    [SerializeField] private bool isActive;

    public void Start() {
        isActive = false; 
        jellyTransform = jelly.GetComponent<Transform>();
        toTransform = to.GetComponent<Transform>();
        jellyRigidbody = jelly.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Jelly>() != null && isActive)
        {
            Vector2 enteringVelocity = jellyRigidbody.velocity;

            jellyTransform.position = toTransform.position;   // teleport the jelly
            float beta = transform.eulerAngles.z + to.transform.eulerAngles.z;     // rotate the velocity vector beta degrees

            jelly.GetComponent<Rigidbody2D>().velocity = Vector2Extension.Rotate(enteringVelocity, beta);
        }
    }

    public bool IsActive
    {
        get {
            return isActive;
        } set {
            isActive = value;
        }
    }

}
