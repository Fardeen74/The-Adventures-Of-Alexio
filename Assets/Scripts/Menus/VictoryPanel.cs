using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class VictoryPanel : MonoBehaviour
{
    public string MainMenuScene;
    public string GameScene;

    public void Playagain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(GameScene);
    }

    public void OpenMainMenu()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
        SceneManager.LoadScene(MainMenuScene);
    }

    public void QuitFromVictoryPanel()
    {
        Application.Quit();
        Debug.Log("Game quitted");
    }
}
