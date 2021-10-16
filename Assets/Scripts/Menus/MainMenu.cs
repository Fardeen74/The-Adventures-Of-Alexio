using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string GameScene;
    public GameObject OptionsScreen;

   public void StartGame()
    {
        SceneManager.LoadScene(GameScene);

    }

    public void OpenOptions()
    {
        OptionsScreen.SetActive(true);

    }

    public void ClosedOptions()
    {
        OptionsScreen.SetActive(false);

    }


    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game quitted");

    }
}
