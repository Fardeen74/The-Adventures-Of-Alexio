using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryUIDisplay : MonoBehaviour
{
    public GameObject victoryScreenUI;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(GameManager.instance.robotsDestroyed == 3)
        {
            victoryScreenUI.SetActive(true);
            Time.timeScale = 0f;
            GameManager.instance.isOtherUIActive = true;
            GameManager.instance.robotsDestroyed = 0;
        }
    }
}
