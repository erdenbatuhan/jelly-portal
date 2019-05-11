using UnityEngine;
using Extensions;

public class Portal : MonoBehaviour {

    /* ----- Class Constants ----- */

    /* ----- Cached Variables (Components) ----- */
    Transform nextTransform;

    /* ----- Editor Variables ----- */
    [SerializeField] Portal next;
    [SerializeField] bool portalActivated = false;

    /* ----- Class Variables ----- */

    void Start() {
        nextTransform = next != null ? next.GetComponent<Transform>() : null;
    }

    void OnTriggerEnter2D(Collider2D collidingObject) {
        Jelly jellyColliding = collidingObject.GetComponent<Jelly>();

        if (portalActivated && jellyColliding != null) {
            HandleTeleportation(jellyColliding);
        }
    }

    void HandleTeleportation(Jelly jellyColliding) {
        if (nextTransform == null) {
            return;
        }

        Vector2 enteringVelocity = jellyColliding.GetVelocity();
        float rotationDegree = transform.eulerAngles.z + nextTransform.eulerAngles.z;
        
        jellyColliding.SetPosition(nextTransform.position);
        jellyColliding.SetVelocity(Vector2Extension.Rotate(enteringVelocity, rotationDegree));
    }

    /* ----- Getters & Setters ----- */
    public bool IsPortalActivated() {
        return portalActivated;
    }

    public void SetPortalActivated(bool portalActivated) {
        this.portalActivated = portalActivated;
    }
}
