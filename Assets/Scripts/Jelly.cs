using System.Collections;
using UnityEngine;
using UnityEditor;

public class Jelly : MonoBehaviour {

	/* ----- Class Constants ----- */

	/* ----- Cached Variables (Components) ----- */
	BoxCollider2D boxColliderComponent;
	Rigidbody2D rigidbodyComponent;
	SpriteRenderer spriteRendererComponent;
	Transform transformComponent;

	/* ----- Editor Variables ----- */
	[SerializeField] LevelController levelController;
	[SerializeField] float initialHealth;

	/* ----- Class Variables ----- */
	float currentHealth;

	void Start() {
		boxColliderComponent = GetComponent<BoxCollider2D>();
		rigidbodyComponent = GetComponent<Rigidbody2D>();
		spriteRendererComponent = GetComponent<SpriteRenderer>();
		transformComponent = GetComponent<Transform>();

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

		if (currentHealth <= 0) {
			EditorUtility.DisplayDialog("=(", "Sorry but you're dead..", "Try again!");

			Destroy(gameObject);
			levelController.LoadNextScene();
		}
	}

	public void GetDisappeared() {
		spriteRendererComponent.enabled = false;

		rigidbodyComponent.isKinematic = true;
		rigidbodyComponent.velocity = Vector2.zero;
	}

	public void GetThrownWhileNotMoving(Vector2 nextPosition, Vector2 throwingVelocity) {
		spriteRendererComponent.enabled = true;
		transformComponent.position = nextPosition;

		rigidbodyComponent.isKinematic = false;
		rigidbodyComponent.velocity = throwingVelocity;
	}

	/* ----- Getters & Setters ----- */
	public Vector2 GetVelocity() {
		return rigidbodyComponent.velocity;
	}

	public void SetVelocity(Vector2 velocity) {
		rigidbodyComponent.velocity = velocity;
	}

	public Vector2 GetPosition() {
		return transformComponent.position;
	}

	public void SetPosition(Vector2 position) {
		transformComponent.position = position;
	}

	public float GetCurrentHealth() {
		return currentHealth;
	}

	public void SetCurrentHealth(float currentHealth) {
		this.currentHealth = currentHealth;
	}

	public void SetKinematic(bool isKinematic) {
		rigidbodyComponent.isKinematic = isKinematic;
	}
}
