using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLevelTrigger : MonoBehaviour
{
    public GameObject finalLevelEnemSpawner;
    public GameObject victoryUIDisplay;
    public bool isTriggered = false;
   


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isTriggered == false)
        {
            finalLevelEnemSpawner.SetActive(true);
            victoryUIDisplay.SetActive(true);
        }
        isTriggered = true;
    }
    
}
