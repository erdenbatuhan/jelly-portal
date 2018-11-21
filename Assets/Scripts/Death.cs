using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Death : MonoBehaviour
{
    [SerializeField] private int lives;
    [SerializeField] Jelly jelly;
    [SerializeField] TextMeshProUGUI deathWriting;
    [SerializeField] GameController gameController;

    private void Start() {
        lives = jelly.Lives;
    }

    public void LoseLife()
    {
        if (gameController.GameHasStarted) {
            lives--;

            if (lives <= 0) {
                deathWriting.text = "You are dead!";
                Destroy(jelly.gameObject);
                gameController.GameHasStarted = false;
            }
        }
    }
}
