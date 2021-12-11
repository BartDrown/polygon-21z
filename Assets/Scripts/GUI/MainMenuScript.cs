using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // In order to change scenes in unity we need this

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private void playGame() // public so that we can call it from button
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("demo"); // Get to the next scene
    }

    [SerializeField] private void quitGame()
    {
        Debug.Log("Game should quit now");
        Application.Quit();
    }
}
