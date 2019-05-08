using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool GameIsPaused = false;
	public GameObject pauseMenuUI;

	private void Awake() {
		pauseMenuUI.SetActive(false);
	}

	public void ShowPauseMenu() {
		pauseMenuUI.SetActive(true);
	}

	public void ClosePauseMenu() {
		pauseMenuUI.SetActive(false);
	}

	public void Resume() {
		ClosePauseMenu();
		Time.timeScale = 1f;
		GameIsPaused = false;
	}

	public void Pause() {
		ShowPauseMenu();
		Time.timeScale = 0f;
		GameIsPaused = true;
	}

	public void LoadMenu() {
		Debug.Log("Loading the menu.");
		// SceneManager.LoadScene("Menu"); TODO: we will fill this later with scenename
	}

	public void QuitGame() {
		Debug.Log("Quitting the game.");
		Application.Quit();
	}
}
