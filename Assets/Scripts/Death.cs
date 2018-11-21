using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Death : MonoBehaviour
{
    [SerializeField] private int lives;
    [SerializeField] Jelly jelly;
    [SerializeField] TextMeshProUGUI deathWriting;

    public void LoseLife()
    {
        Debug.Log("losing lives");
        lives--;
        Debug.Log(lives);

        if (lives <= 0)
        {
            deathWriting.text = "You are dead!";
            Destroy(jelly.gameObject);
        }
    }
}
