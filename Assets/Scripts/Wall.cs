using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision) {
        GameObject collider = collision.gameObject;
        Jelly jelly = collider.GetComponent<Jelly>();

        if (jelly != null) {
            collider.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            jelly.IsThrowable = true;
        }
    } 
}
