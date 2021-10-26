using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class PauseOptions : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    public GameObject pausedOptionsPanel;

    public GameObject player;
    public PlayerHealth playerHealthScript;

    public GameObject savePopup;
    public GameObject loadPopup;

    string playerName;


    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    public void BackToPausedMenu()
    {
        pausedOptionsPanel.SetActive(false);

    }

    private Save createSaveGameobject()
    {
        Save save = new Save();

        save.playerPositionX = player.transform.position.x;
        save.playerPositionY = player.transform.position.y;

        save.playerCurrentWeapon = player.GetComponent<Player>().currentWeapon;
        save.playerhealth = player.GetComponent<PlayerHealth>().health;

        return save;
    }

    private void SaveByJson()
    {
        Save save = createSaveGameobject();
        string JsonString = JsonUtility.ToJson(save);
        StreamWriter sw = new StreamWriter(Application.persistentDataPath + (playerName + ".txt"));
        sw.Write(JsonString);
        sw.Close();
        Debug.Log("===========Saved========");
        //Debug.Log(Application.persistentDataPath);
    }

    private void LoadByJson()
    {
        if (File.Exists(Application.persistentDataPath + (playerName + ".txt")))
        {
            StreamReader sr = new StreamReader(Application.persistentDataPath + (playerName + ".txt"));
            string JsonString = sr.ReadToEnd();
            sr.Close();

            Save save = JsonUtility.FromJson<Save>(JsonString);

            Debug.Log("===========Loaded========");
            player.transform.position = new Vector2(save.playerPositionX, save.playerPositionY);
            player.GetComponent<PlayerHealth>().health = save.playerhealth;
            player.GetComponent<Player>().currentWeapon = save.playerCurrentWeapon;
        }
        else
        {
            Debug.Log("Save data file not found");
        }
    }

    public void SaveButton()
    {
        savePopup.SetActive(true); 
    }

    public void savePlayerName(string s)
    {
        playerName = s;
        Debug.Log(playerName);
    }

    public void BackFromSave()
    {
        savePopup.SetActive(false);
    }

    public void BackFromLoad()
    {
        loadPopup.SetActive(false);
    }

    public void LoadButton()
    {
        loadPopup.SetActive(true);
    }

    public void DoneSaveButton()
    {
        SaveByJson();
        savePopup.SetActive(false);
    }

    public void DoneLoadButton()
    {
        LoadByJson();
        loadPopup.SetActive(false);

        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
    }

}
