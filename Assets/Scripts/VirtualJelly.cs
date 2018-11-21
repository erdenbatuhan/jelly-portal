using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualJelly : MonoBehaviour {

    /* Global Variables */
    [SerializeField] Jelly jelly;
    private bool isHeld = false;
    private Vector2 velocityVector;
    private const float releaseTime = 0.05f;
    public GameController gameController;
    /* Cached Variables */
    Rigidbody2D rigidbody;

    private void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        gameController = FindObjectOfType<GameController>();
    }
	
	private void Update () {
        if (isHeld) {
           GetComponent<SpriteRenderer>().enabled = false;
           rigidbody.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void OnMouseDown() {
        isHeld = true;
        rigidbody.isKinematic = true;
    }

    private void OnMouseUp() {
        isHeld = false;
        rigidbody.isKinematic = false;
        StartCoroutine(Release());
    }

    private IEnumerator Release() {
        yield return new WaitForSeconds(releaseTime);
        GetComponent<SpringJoint2D>().enabled = false;
        jelly.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        velocityVector = rigidbody.velocity;
        Destroy(gameObject);
        jelly.throwJelly();
        gameController.GameHasStarted = true;
    }

    public Vector2 VelocityVector {
        get {
            return velocityVector;
        } set {
            velocityVector = value;
        }
    }
}
