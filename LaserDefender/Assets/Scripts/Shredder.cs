using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
    // Other object is a variable name and the gameObject is the laser.
    // The variable is created in the void. 
{
    private void OnCollisionEnter2D(Collision2D otherObject)
    {
        print(otherObject.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        Destroy(otherObject.gameObject); 
    }
}
