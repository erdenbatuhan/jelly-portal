using UnityEngine;

public class PortalActivator : MonoBehaviour {

	/* ----- Class Constants ----- */

	/* ----- Cached Variables (Components) ----- */
	Portal parent;

	/* ----- Editor Variables ----- */

	/* ----- Class Variables ----- */

	void Start() {
		parent = GetComponentInParent<Portal>();
	}

	void OnTriggerEnter2D(Collider2D collidingObject) {
		parent.SetPortalActivated(true);
	}

	void OnTriggerExit2D(Collider2D collidingObject) {
		parent.SetPortalActivated(true);
	}

	/* ----- Getters & Setters ----- */
}
