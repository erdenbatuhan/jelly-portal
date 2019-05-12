using UnityEngine;

public class GameController : MonoBehaviour {

	/* ----- Class Constants ----- */

	/* ----- Cached Variables (Components) ----- */

	/* ----- Editor Variables ----- */

	/* ----- Class Variables ----- */
	bool gameStarted;

	void Start() {
		gameStarted = false;
	}

	/* ----- Getters & Setters ----- */
	public bool IsGameStarted() {
		return gameStarted;
	}

	public void SetGameStarted(bool gameStarted) {
		this.gameStarted = gameStarted;
	}
}
