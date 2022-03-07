using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] enemiesToSpawn;


    // Update is called once per frame
    void Update()
    {
        if ( Random.Range(1,200) < 5)
        {
            //make start position
            Vector3 spawnPosition = this.transform.position;
            spawnPosition.y += Random.Range( -5f, 5f);

            //Randomizes enemy spawns
            int randomEnemyPosition = Random.Range(0,2);
            
            //spawns the random enemy
            Instantiate(enemiesToSpawn[randomEnemyPosition], spawnPosition, Quaternion.identity);
        }
        
    }
}
