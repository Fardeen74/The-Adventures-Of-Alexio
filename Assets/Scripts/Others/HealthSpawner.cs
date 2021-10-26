using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawner : MonoBehaviour
{
    public GameObject HealthPSpawn;
    //public float timeToSpawn;
    //private float currentTimetoSpwan;


    private void Start()
    {
        SpawnHealthPack();
    }
    void Update()
    {
        /*if(currentTimetoSpwan > 0)
        {
            currentTimetoSpwan -= Time.deltaTime;
        }

        else
        {
            SpawnHealthPack();
            currentTimetoSpwan = timeToSpawn;
        }*/

    }
    public void SpawnHealthPack()
    {
        Instantiate(HealthPSpawn, transform.position, transform.rotation);

    }


    
}
