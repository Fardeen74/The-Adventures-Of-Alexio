using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    
    public GameObject pauseOptionsPanel;
    
    public string MainMenuScene;


    private void Start()
    {
        if(GameManager.instance.isOtherUIActive == true)
        {
            GameManager.instance.isOtherUIActive = false;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.instance.isOtherUIActive == false)
        {
            Cursor.visible = true;
            if (GameIsPaused)
            {
                Resume();
            }

            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void OpeningMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(MainMenuScene);
    }

    public void PausedOptions()
    {
        pauseOptionsPanel.SetActive(true);
    }
}

