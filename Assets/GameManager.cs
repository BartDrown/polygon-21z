using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameHasEnded = false;
    // float restartDelay = 5f; // How long do we wait before restarting scene, 1 second by default

    public void EndGame()
    {
        if(!gameHasEnded)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            // Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Load the current scene
    }
}
