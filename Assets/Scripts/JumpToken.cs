using UnityEngine;

public class JumpToken : MonoBehaviour {

	/* ----- Class Constants ----- */

	/* ----- Cached Variables (Components) ----- */

	/* ----- Editor Variables ----- */
	[SerializeField] float jumpingMagnitudeInX = 1.5f;
	[SerializeField] float jumpingMagnitudeInY = 3.0f;

	/* ----- Class Variables ----- */

	void OnTriggerEnter2D(Collider2D collidingObject) {
		Jelly jellyColliding = collidingObject.GetComponent<Jelly>();

		if (jellyColliding != null) {
			PushJelly(jellyColliding);
		}
	}

	void PushJelly(Jelly jellyColliding) {
		float x = jellyColliding.GetVelocity().x + jumpingMagnitudeInX;
		float y = jellyColliding.GetVelocity().y + jumpingMagnitudeInY;

		Vector2 jumpingVelocity = new Vector2(x, y);
		jellyColliding.SetVelocity(jumpingVelocity);
	}

	/* ----- Getters & Setters ----- */
}
