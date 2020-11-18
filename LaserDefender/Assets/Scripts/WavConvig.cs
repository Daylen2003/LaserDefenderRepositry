using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Enemy wave config")]
public class WavConvig : ScriptableObject
{
    //the enemy sprite
    [SerializeField] GameObject enemyPrefeb;

    //the path to follow
    [SerializeField] GameObject pathPrefeb;

    //time between enemy spawn
    [SerializeField] float timeBetweenSpawns = 0.5f;

    //random time difference between spawns
    [SerializeField] float spawnRandomfactor = 0.3f;

    //number of enemies in wav
    [SerializeField] int numberOfEnemies = 5;

    //enemy movement speed
    [SerializeField] float EnemyMovement = 2f;

}
