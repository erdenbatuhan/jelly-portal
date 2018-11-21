using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpToken : MonoBehaviour {
    [SerializeField] Jelly jelly;

	private void OnTriggerEnter2D(Collider2D collider) {
        jelly.GetComponent<Rigidbody2D>().velocity = new Vector2(3, 6);
    }
}
