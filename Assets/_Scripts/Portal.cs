using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
    [SerializeField] Jelly jelly;
    [SerializeField] Portal destination;
    Transform jellyTransform;
    Transform destinationTransform;

    public void Start() { 
        jellyTransform = jelly.GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Jelly>() != null)
        {
            destinationTransform = destination.GetComponent<Transform>();
            jellyTransform.position = destinationTransform.position;
            jellyTransform.eulerAngles = new Vector3(jellyTransform.eulerAngles.x, jellyTransform.eulerAngles.y, destinationTransform.eulerAngles.z);
            Vector3 velocityVector = jelly.GetComponent<Rigidbody2D>().velocity;
            /*float velX = velocityVector.x;
            float velY = -velocityVector.y;

            jelly.GetComponent<Rigidbody2D>().velocity = new Vector3(velX, velY, 0);
 */
        }
    }

}
