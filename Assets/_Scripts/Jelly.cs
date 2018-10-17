using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour {
    [SerializeField] float velocityInX;
    [SerializeField] float velocityInY;

	// Use this for initialization
	void Start () {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(velocityInX, velocityInY);
	}
}
