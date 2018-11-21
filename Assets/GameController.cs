using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    [SerializeField] private bool gameHasStarted;

    // Use this for initialization
    void Start() {
        gameHasStarted = false;
    }

    public bool GameHasStarted {
        get  {
            return gameHasStarted;
        } set {
            gameHasStarted = value;
        }
    }
}
