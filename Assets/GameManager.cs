using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameHasEnded = false;
    float restartDelay = 5f; // How long do we wait before restarting scene, 1 second by default

    private int killCount;

    [SerializeField]
    private KillCounter killCounter;

    public void EndGame()
    {
        if(!gameHasEnded)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        killCount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Load the current scene
    }

    public void increaseKillCount(){
        ++killCount;
        killCounter.updateKillCounter(killCount);
    }

    
}
