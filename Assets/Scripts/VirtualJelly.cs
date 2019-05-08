using System.Collections;
using UnityEngine;

public class VirtualJelly : MonoBehaviour {

    /* ----- Class Constants ----- */

    /* ----- Cached Variables (Components) ----- */
    BoxCollider2D boxColliderComponent;
    Rigidbody2D rigidbodyComponent;
    SpringJoint2D springJointComponent;
    SpriteRenderer spriteRendererComponent;

    /* ----- Editor Variables ----- */
    [SerializeField] float releaseTime = 0.05f;
    [SerializeField] Jelly jelly;

    /* ----- Class Variables ----- */
    bool beingPulled;
    Vector2 springForce;

    void Start() {
        boxColliderComponent = GetComponent<BoxCollider2D>();
        rigidbodyComponent = GetComponent<Rigidbody2D>();
        springJointComponent = GetComponent<SpringJoint2D>();
        spriteRendererComponent = GetComponent<SpriteRenderer>();

        beingPulled = false;
    }
	
	void Update() {
        if (beingPulled) {
            rigidbodyComponent.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    void OnMouseDown() {
        beingPulled = true;
        rigidbodyComponent.isKinematic = true;
    }

    void OnMouseUp() {
        beingPulled = false;
        rigidbodyComponent.isKinematic = false;

        StartCoroutine(Release());
    }

    IEnumerator Release() {
        yield return new WaitForSeconds(releaseTime);

        boxColliderComponent.enabled = false;
        springJointComponent.enabled = false;
        spriteRendererComponent.enabled = false;

        StartCoroutine(jelly.ThrowJelly(rigidbodyComponent.velocity));
    }
}
