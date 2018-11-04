using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualJelly : MonoBehaviour {

    /* Global Variables */
    [SerializeField] Jelly jelly;
    private bool isPressed, whileHolding = false;
    private const float releaseTime = 0.05f;
    /* Cached Variables */
    Rigidbody2D myRigidbody;

    private void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();

    }
	
	private void Update () {
        if (isPressed) {
            whileHolding = true;
            GetComponent<SpriteRenderer>().enabled = false;
            myRigidbody.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);        
        } 
        if (whileHolding) { 
            jelly.GetComponent<Rigidbody2D>().velocity = myRigidbody.velocity;
            GetComponent<BoxCollider2D>().enabled = true;
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
        jelly.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject);
    }
}
