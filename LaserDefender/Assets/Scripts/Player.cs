using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    //makes the variable editable from unity editor. 
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] GameObject laserPrefeb;
    [SerializeField] float laserSpeed = 15f;

    float xMin, xMax, yMin, yMax ;
    
    float padding = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBounderies();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    
   
    private void SetUpMoveBounderies()
    {   //Set up the boundaries of movment according to camera
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    private void Fire()
    {
        //if fire is pressed  spawn a laser at the player ship position

        if(Input.GetButtonDown("Fire1"))
        {
            GameObject laser = Instantiate(laserPrefeb, transform.position, Quaternion.identity) as GameObject;
            // Give the laser a velocity in the Y-axis.
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserSpeed);
        }

    }

    private void Move()
    {
        //var is a generic variable which changes its type to according to value
        //deltaX is the difference the Player Ship moves in the x-axis.
         var deltaX= Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        //newXpostion = current position was in x = the difference moved in x-axis. 
         var newXPos = transform.position.x +deltaX;
        //clamp the value of newXpos between xMin(0) and xMax (1)
        newXPos = Mathf.Clamp(newXPos, xMin, xMax);

        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newYpos = transform.position.y + deltaY;
        //clamp the value of newYpos between yMin(0) and yMax (1)
        newYpos = Mathf.Clamp(newYpos, yMin, yMax);
        //move the player ship on the x-axis only. (newXPos) 
        transform.position = new Vector2(newXPos,newYpos);
        

        
    }

}
