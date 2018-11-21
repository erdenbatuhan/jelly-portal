using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidingDeath : MonoBehaviour {
    [SerializeField] Death death;
    [SerializeField]
    VirtualJelly virtualJelly;
	
	private void OnTriggerEnter2D(Collider2D collider)
    {
        if (virtualJelly.gameHasStarted) { 
        Debug.Log("hi in collider");
        death.LoseLife();
        }
    }
}
