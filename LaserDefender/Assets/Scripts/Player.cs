using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    //makes the variable editable from unity editor. 
    [SerializeField] int health = 100;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] GameObject laserPrefeb;
    [SerializeField] float laserSpeed = 15f;
    [SerializeField] float laserFiringTime = 0.2f;

    [SerializeField] AudioClip playerDeathSound;
    [SerializeField] [Range(0, 1)] float playerDeathSoundVolume = 0.75f;

    [SerializeField] AudioClip playerShootSound;
    [SerializeField] [Range(0, 1)] float playerShootSoundVolume = 0.1f;

    bool coroutinestarted = false; 
    // Coroutine printCoroutine;
    Coroutine FireCoroutine;


    float xMin, xMax, yMin, yMax ;
    
    float padding = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBounderies();
        //printCoroutine = StartCoroutine(PrintAndWait());
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    //coruotine example
    // yield means to let the second message to be printed after 10 seconds

    //private IEnumerator PrintAndWait()
    //{
    // prints message 1 after 10 seconds
    // print message 2
    //  print("message 1");
    // yield return new WaitForSeconds(10);
    // print("message 2 after 10 seconds");
    // }

    private IEnumerator FireContinouisly()
    {
        while (true) // While coroutine is running 
        {
            GameObject laser = Instantiate(laserPrefeb, transform.position, Quaternion.identity) as GameObject;
            // Give the laser a velocity in the Y-axis.
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserSpeed);
            AudioSource.PlayClipAtPoint(playerShootSound, Camera.main.transform.position, playerShootSoundVolume);

            yield return new WaitForSeconds(laserFiringTime);
        }
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
            // if coroutine has not started 
            // to avoid starting more than one same coroutine
            if (!coroutinestarted)// If coroutine started == false
            {
                //start coroutine
                FireCoroutine = StartCoroutine(FireContinouisly());
                //set coroutine = true
                coroutinestarted = true;
            }
            
        }

        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(FireCoroutine);
            coroutinestarted = false; 
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
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        // access damage dealer from other object that hit the enemy, and reduce health accordingly.
        DamageDealer dmg = otherObject.gameObject.GetComponent<DamageDealer>();
        ProcessHit(dmg);
    }

    private void ProcessHit(DamageDealer dmg)
    {
        health -= dmg.GetDamage();

        dmg.Hit();// so that the laser is destroyed when hit the object. 

        if (health <= 0)
        {

            Die(); 
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(playerDeathSound, Camera.main.transform.position, playerDeathSoundVolume);
    }
}
