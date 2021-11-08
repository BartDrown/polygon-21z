using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // In order to change scenes in unity we need this

public class mainMenuScript : MonoBehaviour
{
    public void playGame() // public so that we can call it from button
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevelIndex + 1); // Get to the next scene
    }

    public void quitGame()
    {
        Debug.Log("Game should quit now");
        Application.Quit();
    }
}
