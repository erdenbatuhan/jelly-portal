using UnityEngine;

public class Enemy : MonoBehaviour {

    /* ----- Class Constants ----- */

    /* ----- Cached Variables (Components) ----- */

    /* ----- Editor Variables ----- */
    [SerializeField] float damage = Mathf.Infinity;

    /* ----- Class Variables ----- */
	
	void OnTriggerEnter2D(Collider2D objectColliding) {
        Jelly jelly = objectColliding.GetComponent<Jelly>();

        if (jelly != null) {
            jelly.GetHit(damage);
        }
    }

    /* ----- Getters & Setters ----- */
}
