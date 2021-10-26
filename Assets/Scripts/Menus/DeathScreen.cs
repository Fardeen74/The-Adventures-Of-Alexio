using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject deathScreenUI;
    public GameObject loadGamePanel;
 

    public string GameScene;
    public string MainMenuScene;


   

   public void ActiveDeathScreen()
   {
        deathScreenUI.SetActive(!deathScreenUI.activeSelf);
   }

    public void TryAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(GameScene);
    }

    public void OpeningMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(MainMenuScene);
    }

    public void LoadfromDeathscreen()
    {
        loadGamePanel.SetActive(true);
        deathScreenUI.SetActive(false);
        
    }
}
