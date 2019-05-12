using UnityEngine;

public class PauseMenu : MonoBehaviour {

	/* ----- Class Constants ----- */

	/* ----- Cached Variables (Components) ----- */

	/* ----- Editor Variables ----- */

	/* ----- Class Variables ----- */
	bool gamePaused = false;
	GameObject pauseMenuUI;

	void Start() {
		gamePaused = false;
	}

	void Awake() {
		pauseMenuUI.SetActive(false);
	}

	public void Pause() {
		Time.timeScale = 0f;
		gamePaused = true;

		ShowPauseMenu();
	}

	public void ShowPauseMenu() {
		pauseMenuUI.SetActive(true);
	}

	public void Resume() {
		Time.timeScale = 1f;
		gamePaused = false;

		ClosePauseMenu();
	}

	public void ClosePauseMenu() {
		pauseMenuUI.SetActive(false);
	}

	/* ----- Getters & Setters ----- */
}
