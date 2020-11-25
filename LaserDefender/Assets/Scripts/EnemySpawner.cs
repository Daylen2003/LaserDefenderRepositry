using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WavConvig> waveConfigList;

    //start from 0 
    int startingWave = 0;
    // Start is called before the first frame update
    void Start()
    {
        // Set the current move to the first wave (0)
        var currentWave = waveConfigList[startingWave];

        StartCoroutine(SpawnAllEnemiesInWave(currentWave));
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    // waveToSpawn is a variable name to identify that specigic WavConfig
    private IEnumerator SpawnAllEnemiesInWave(WavConvig waveToSpawn)
    {
        for(int enemyCount = 1; enemyCount <= waveToSpawn.GetNumberOfEnemies(); enemyCount++)
        {
            var newEnemy = Instantiate(
                       waveToSpawn.GetEnemyPrefab(),
                       waveToSpawn.GetWayPointLists()[0].transform.position,
                       Quaternion.identity) as GameObject;
            yield return new WaitForSeconds(waveToSpawn.GetTimeBetweenSpawns());

        }
        //spawn the enemy prefeb from waveToSpawn
        //at the position of 1st waypoint in Path.

    }
}
