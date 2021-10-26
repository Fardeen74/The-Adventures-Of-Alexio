using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string GameScene;
    public GameObject OptionsPanel;
    public GameObject ControlsPanel;

   public void StartGame()
    {
        SceneManager.LoadScene(GameScene);

    }

    public void OpenOptions()
    {
        OptionsPanel.SetActive(true);

    }

    public void CloseOptions()
    {
        OptionsPanel.SetActive(false);

    }

    public void OpenControls()
    {
        ControlsPanel.SetActive(true);
    }
    public void CloseControls()
    {
        ControlsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game quitted");

    }
}
