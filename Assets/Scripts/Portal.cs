using UnityEngine;
using Extensions;

public class Portal : MonoBehaviour {

    /* ----- Class Constants ----- */

    /* ----- Cached Variables (Components) ----- */
    Transform nextTransform;

    /* ----- Editor Variables ----- */
    [SerializeField] Jelly jelly;
    [SerializeField] Portal next;
    [SerializeField] bool portalActivated = false;

    /* ----- Class Variables ----- */

    void Start() {
        nextTransform = next.GetComponent<Transform>();
    }

    void OnTriggerEnter2D(Collider2D collidingObject) {
        bool jellyCollided = collidingObject.GetComponent<Jelly>() != null;

        if (jellyCollided && portalActivated) {
            HandleTeleportation();
        }
    }

    void HandleTeleportation() {
        Vector2 enteringVelocity = jelly.GetVelocity();
        float rotationDegree = transform.eulerAngles.z + nextTransform.eulerAngles.z;
        
        jelly.SetPosition(nextTransform.position);
        jelly.SetVelocity(Vector2Extension.Rotate(enteringVelocity, rotationDegree));
    }

    /* ----- Getters & Setters ----- */
    public bool IsPortalActivated() {
        return portalActivated;
    }

    public void SetPortalActivated(bool portalActivated) {
        this.portalActivated = portalActivated;
    }
}
