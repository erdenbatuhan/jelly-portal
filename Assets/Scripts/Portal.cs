using System.Collections;
using UnityEngine;
using Extensions;

public class Portal : MonoBehaviour {

	/* ----- Class Constants ----- */
	const float TELEPORTATION_DELAY = .25f;

	/* ----- Cached Variables (Components) ----- */
	Transform nextTransform;

	/* ----- Editor Variables ----- */
	[SerializeField] Portal next;

	/* ----- Class Variables ----- */
	bool portalActivated = false;
	bool beingTeleportedTo = false;

	void Start() {
		nextTransform = next != null ? next.GetComponent<Transform>() : null;
	}

	void OnTriggerEnter2D(Collider2D collidingObject) {
		Jelly jellyColliding = collidingObject.GetComponent<Jelly>();

		if (portalActivated && jellyColliding != null) {
			StartCoroutine(HandleTeleportation(jellyColliding));
		}
	}

	IEnumerator HandleTeleportation(Jelly jellyColliding) {
		if (nextTransform == null) {
			yield return null;
		}

		beingTeleportedTo = false;
		next.SetBeingTeleportedTo(true);

		Vector2 enteringVelocity = jellyColliding.GetVelocity();
		float rotationDegree = transform.eulerAngles.z + nextTransform.eulerAngles.z;

		jellyColliding.GetDisappeared();

		yield return new WaitForSeconds(TELEPORTATION_DELAY);

		jellyColliding.GetThrownWhileNotMoving(nextTransform.position, Vector2Extension.Rotate(enteringVelocity, rotationDegree));
	}

	/* ----- Getters & Setters ----- */
	public bool IsPortalActivated() {
		return portalActivated;
	}

	public void SetPortalActivated(bool portalActivated) {
		this.portalActivated = portalActivated;
	}

	public bool IsBeingTeleportedTo() {
		return beingTeleportedTo;
	}

	public void SetBeingTeleportedTo(bool beingTeleportedTo) {
		this.beingTeleportedTo = beingTeleportedTo;
	}
}
