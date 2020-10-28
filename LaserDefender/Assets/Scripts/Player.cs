using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move(); 
    }

    private void Move()
    {
        //var is a generic variable which changes its type to according to value
        //deltaX is the difference the Player Ship moves in the x-axis.
         var deltaX= Input.GetAxis("Horizontal");
        //newXpostion = current position was in x = the difference moved in x-axis. 
         var newXPos = transform.position.x +deltaX;
        //move the player ship on the x-axis only. (newXPos) 
        transform.position = new Vector2(newXPos,transform.position.y);

        
    }

}
