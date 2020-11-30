using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WavConvig> waveConfigList;

    [SerializeField] bool looping = false; 

    
    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        //When coroutine SpawnAllWaves finishes if looping == true
        while (looping); // while looping == true
        
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
            // setting the wave as a component to the enemy
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveToSpawn);

            yield return new WaitForSeconds(waveToSpawn.GetTimeBetweenSpawns());

        }
        //spawn the enemy prefeb from waveToSpawn
        //at the position of 1st waypoint in Path.

    }
    private IEnumerator SpawnAllWaves()
    {
        // curret wave is a new variable
        // acccess each wave I have in wavConfig list
        // and wait for all enemies in that wave to spawn
        // before looping again
        foreach (WavConvig currentWave in waveConfigList)
        {
            // before yielding and returning 
            // spawn all enemies in wave

            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }
}
