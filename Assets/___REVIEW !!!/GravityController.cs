using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour {
    private bool isReverted = false;
    private Vector2 gravity;    // always holds the current gravity value of the game.

    private void Start() {
        Gravity = Physics2D.gravity;
    }

    public void revertGravity() {
        Gravity = new Vector2(Gravity.x, - Gravity.y);
        Physics2D.gravity = Gravity;
        Gravity = gravity;
        IsReverted = !isReverted;
    }

    public bool IsReverted {
        get {
            return isReverted;
        } set {
            isReverted = value;
        }
    }

    public Vector2 Gravity {
        get {
            return gravity;
        } set {
            gravity = value;
            Physics2D.gravity = Gravity;

            if (value.x < 0) 
                IsReverted = true;
        }
    }

}
