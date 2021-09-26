using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void nextLevel()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void mainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
