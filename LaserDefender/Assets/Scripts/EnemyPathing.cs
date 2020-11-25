using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    // A list of type transform as waypoints are at postions in x and y. 
    //Transform because our list is made from x and y-axis. 
    [SerializeField] List<Transform> waypointsList;

    [SerializeField] float enemeyMoveSpeed = 2f;

    [SerializeField] WavConvig waveConfig;
    // shows the next waypoint
    int waypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        // To update enemy path. 
        waypointsList = waveConfig.GetWayPointLists();

        // Set the starting position of the enemy ship to the 1st waypoint
        transform.position = waypointsList[waypointIndex].transform.position;

       
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    private void EnemyMove()
    {
        // 0 , 1 , 2     <       3
        if(waypointIndex < waypointsList.Count)
        {
            // Set the target position to the next waypoint position.
            //  Tragetposition where we want to go.
            var targetPosition = waypointsList[waypointIndex].transform.position;
            
            targetPosition.z = 0f;
            //enemyMovement per frame 
            var enemnyMovement = enemeyMoveSpeed * Time.deltaTime;

            //move from current position, to target position, at enemy movement speed
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, enemnyMovement);

            // check if we reached the new target position
            if(transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        //if enemy reached last waypoint
        else
        {
            Destroy(gameObject); 
        }
    }
}
