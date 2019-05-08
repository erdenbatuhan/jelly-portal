using System.Collections;
using UnityEngine;
using UnityEditor;

public class Jelly : MonoBehaviour {

    /* ----- Class Constants ----- */

    /* ----- Cached Variables (Components) ----- */
    BoxCollider2D boxColliderComponent;
    Rigidbody2D rigidbodyComponent;

    /* ----- Editor Variables ----- */
    [SerializeField] LevelManager levelManager;
    [SerializeField] float initialHealth;

    /* ----- Class Variables ----- */
    float currentHealth;

    void Start() {
        boxColliderComponent = GetComponent<BoxCollider2D>();
        rigidbodyComponent = GetComponent<Rigidbody2D>();

        boxColliderComponent.enabled = false;
        rigidbodyComponent.isKinematic = true;

        currentHealth = initialHealth;
    }

    public IEnumerator ThrowJelly(Vector2 springForce) {
        boxColliderComponent.enabled = true;

        rigidbodyComponent.isKinematic = false;
        rigidbodyComponent.velocity = springForce;

        yield return null;
    }

    public void GetHit(float damage) {
        currentHealth -= damage;

        if (--currentHealth <= 0) {
            EditorUtility.DisplayDialog("=(", "Sorry but you're dead..", "Try again!");

            Destroy(gameObject);
            levelManager.LoadNextScene();
        }
    }

    /* ----- Getters & Setters ----- */
    public float GetCurrentHealth() {
        return currentHealth;
    }

    public void SetCurrentHealth(float currentHealth) {
        this.currentHealth = currentHealth;
    }
}
