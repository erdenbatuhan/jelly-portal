using UnityEngine;

public class GravityController : MonoBehaviour {

    /* ----- Class Constants ----- */

    /* ----- Cached Variables (Components) ----- */

    /* ----- Editor Variables ----- */

    /* ----- Class Variables ----- */
    bool reverted;

    void Start() {
        reverted = false;
    }

    public void RevertGravityVector() {
        Physics2D.gravity = new Vector2(Physics2D.gravity.x, (-1) * Physics2D.gravity.y);
        reverted = !reverted;
    }

    /* ----- Getters & Setters ----- */
    public bool IsReverted() {
        return reverted;
    }

    public void SetReverted(bool reverted) {
        this.reverted = reverted;
    }
}
