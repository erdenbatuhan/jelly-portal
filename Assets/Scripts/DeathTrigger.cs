using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour {
    [SerializeField] Death death;
	
	private void OnTriggerEnter2D(Collider2D collider) {
        death.LoseLife();
    }
}
