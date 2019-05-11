using UnityEngine;

public class JumpToken : MonoBehaviour {

    /* ----- Class Constants ----- */

    /* ----- Cached Variables (Components) ----- */

    /* ----- Editor Variables ----- */
    [SerializeField] float jumpingMagnitudeInX = 3;
    [SerializeField] float jumpingMagnitudeInY = 6;

    /* ----- Class Variables ----- */
    Vector2 jumpingVelocity;

    void Start() {
        jumpingVelocity = new Vector2(jumpingMagnitudeInX, jumpingMagnitudeInY);
    }

	void OnTriggerEnter2D(Collider2D collidingObject) {
        Jelly jellyColliding = collidingObject.GetComponent<Jelly>();

        if (jellyColliding != null) {
            jellyColliding.SetVelocity(jumpingVelocity);
        }
    }

    /* ----- Getters & Setters ----- */
}
