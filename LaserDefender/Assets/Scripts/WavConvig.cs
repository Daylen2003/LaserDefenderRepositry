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

    // The methods are public whilst the variables are private, this is used so that the user don't have permissions to change anything. 
    public GameObject GetEnemyPrefab()
    {
        return enemyPrefeb;
    }

    public List<Transform> GetWayPointLists()
    {
        //each wave can have different number of waypoints
        var waveWayPoints = new List<Transform>();

        //access the Path prefeb, read each waypoint and add it to the List wavWayPoints.
        //child is a variable name.
        foreach (Transform child in pathPrefeb.transform)
        {
            waveWayPoints.Add(child);
            //wavWayPoints:
            //
            //[0]:waypoint0
            //[1]:waypoint1
            //[2]:waypoint2
        }
        return waveWayPoints;
    }


    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float GetSpawnRandomFactor()
    {
        return spawnRandomfactor;
    }

    public int GetNumberOfEnemies()
    {
        return numberOfEnemies;
    }

    public float GetEnemyMoveSpeed()
    {
        return EnemyMovement;
    }
}

