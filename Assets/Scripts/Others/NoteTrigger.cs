using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteTrigger : MonoBehaviour
{
    public GameObject notepanelUI;

    private bool isNoteActive = false;

    private void Start()
    {
        GameManager.instance.robotsDestroyed = 0;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isNoteActive == false)
        {
            notepanelUI.SetActive(true);
            Time.timeScale = 0f;
        }
        isNoteActive = true;
    }


    public void OkReadyButton()
    {
        notepanelUI.SetActive(false);
        Time.timeScale = 1f;
    }
}
