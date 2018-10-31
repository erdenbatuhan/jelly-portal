using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    private int currentSceneIndex;

	private void Start () {

        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

	}

    public void LoadSplashScene() {
        SceneManager.LoadScene("01. Start");
    }

    public void LoadLevelsScene() {
        SceneManager.LoadScene("02. Levels");
    }
    
    public void LoadSettingsScene() {
        SceneManager.LoadScene("03. Settings");
    }

    public void LoadNextScene() {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void ExitTheGame() {
        Application.Quit();
    }
}
