using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
    /* Cached Variables */
    [SerializeField] Sprite redSprite;
    [SerializeField] Sprite greenSprite;
    private GravityController gravityController;
    private Arrow[] arrows;
    private List<Transform> arrowTransforms;
    private List<SpriteRenderer> arrowSpriteRenderers;

    private void Start() {
        gravityController = FindObjectOfType<GravityController>();
        arrows = FindObjectsOfType<Arrow>();
        arrowTransforms = new List<Transform>();
        arrowSpriteRenderers = new List<SpriteRenderer>();

        foreach (Arrow arrow in arrows) {
            arrowSpriteRenderers.Add(arrow.GetComponent<SpriteRenderer>());
            arrowTransforms.Add(arrow.GetComponent<Transform>());
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        gravityController.revertGravity();
        ChangeSpriteColors();
        RotateAllArrows180Degrees();
    }

    void ChangeSpriteColors() {
        Sprite nextSprite = gravityController.IsReverted ? redSprite : greenSprite;

        foreach (SpriteRenderer spriteRenderer in arrowSpriteRenderers)
            spriteRenderer.sprite = nextSprite;
    }

    private void RotateAllArrows180Degrees() {
        Vector3 revert = new Vector3(180, 0, 0);

        foreach (Transform transform in arrowTransforms) 
            transform.eulerAngles = transform.eulerAngles.Equals(Vector3.zero) ? revert : Vector3.zero;
    }
}
