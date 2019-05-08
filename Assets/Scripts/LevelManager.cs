using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    /* ----- Class Constants ----- */

    /* ----- Cached Variables (Components) ----- */

    /* ----- Editor Variables ----- */

    /* ----- Class Variables ----- */
    int currentSceneIndex;

	void Start() {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
	}

    public void LoadStartScene() {
        SceneManager.LoadScene("01. Start");
    }

    public void LoadLevelsScene() {
        SceneManager.LoadScene("02. Levels");
    }
    
    public void LoadSettingsScene() {
        SceneManager.LoadScene("03. Settings");
    }

    public void LoadNextScene() {
        SceneManager.LoadScene(currentSceneIndex + 1 % SceneManager.sceneCount);
    }

    public void ExitTheGame() {
        Application.Quit();
    }
}
