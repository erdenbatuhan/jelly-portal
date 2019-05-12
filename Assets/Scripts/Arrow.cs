using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	/* ----- Class Constants ----- */

	/* ----- Cached Variables (Components) ----- */
	List<SpriteRenderer> arrowSpriteRendererComponents;
	List<Transform> arrowTransformComponents;

	/* ----- Editor Variables ----- */
	[SerializeField] GravityController gravityController;
	[SerializeField] Sprite greenSprite;
	[SerializeField] Sprite redSprite;

	/* ----- Class Variables ----- */

	void Start() {
		var arrows = FindObjectsOfType<Arrow>();

		arrowSpriteRendererComponents = new List<SpriteRenderer>();
		arrowTransformComponents = new List<Transform>();

		foreach (Arrow arrow in arrows) {
			arrowSpriteRendererComponents.Add(arrow.GetComponent<SpriteRenderer>());
			arrowTransformComponents.Add(arrow.GetComponent<Transform>());
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		gravityController.RevertGravityVector();

		ChangeSpriteColors();
		RevertAllArrows();
	}

	void ChangeSpriteColors() {
		Sprite nextSprite = gravityController.IsReverted() ? redSprite : greenSprite;

		foreach (SpriteRenderer spriteRenderer in arrowSpriteRendererComponents) {
			spriteRenderer.sprite = nextSprite;
		}
	}

	void RevertAllArrows() {
		Vector2 revertingVector = new Vector3(180, Vector2.zero.y);

		foreach (Transform transform in arrowTransformComponents) {
			transform.eulerAngles = transform.eulerAngles.Equals(Vector2.zero) ? revertingVector : Vector2.zero;
		}
	}

	/* ----- Getters & Setters ----- */
}
