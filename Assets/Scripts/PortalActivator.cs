using UnityEngine;

public class PortalActivator : MonoBehaviour {

	/* ----- Class Constants ----- */

	/* ----- Cached Variables (Components) ----- */
	Portal connectedPortal;

	/* ----- Editor Variables ----- */

	/* ----- Class Variables ----- */

	void Start() {
		connectedPortal = GetComponentInParent<Portal>();
	}

	void OnTriggerEnter2D(Collider2D collidingObject) {
		connectedPortal.SetPortalActivated(true);
	}

	void OnTriggerExit2D(Collider2D collidingObject) {
		connectedPortal.SetPortalActivated(false);
	}

	/* ----- Getters & Setters ----- */
}
