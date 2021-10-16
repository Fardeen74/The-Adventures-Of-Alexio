using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> sEnemy = new List<GameObject>();

    public bool isRandomize;


    void Start()
    {
        SpawnSenemy();
        
    }

    
    void Update()
    {
        
    }

    public void SpawnSenemy()
    {
        int index = isRandomize ? Random.Range(0, sEnemy.Count) : 0;
        if(sEnemy.Count > 0)
        {
            Instantiate(sEnemy[index], transform.position, transform.rotation);
        }
        

    }
}
