using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseOptions : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    public GameObject pausedOptionsPanel;

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    public void BackToPausedMenu()
    {
        pausedOptionsPanel.SetActive(false);

    }
}
