using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    [SerializeField] float health = 100;

    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;

    [SerializeField] GameObject enemyLaserPrefab;
    [SerializeField] float enemeyLaserSpeed = 5f;

    [SerializeField] AudioClip enemyDeathSound;
    [SerializeField] [Range(0, 1)] float enemyDeathSoundVolume = 0.75f;

    [SerializeField] AudioClip enemyShootSound;
    [SerializeField] [Range(0, 1)] float enemyShootSoundVolume = 0.3f;

    [SerializeField] GameObject deathEffects;
    [SerializeField]  float explosionDuaration = 1f;

    // otherObject is a variable name, reduce enemy health whenever enemy collides with a gameObject that have a damage dealer component. 
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        // access damage dealer from other object that hit the enemy, and reduce health accordingly.
        DamageDealer dmg = otherObject.gameObject.GetComponent<DamageDealer>();

        if(!dmg) // if object does bit contain damage dealer.
        {
            return; // end the method
        }
        ProcessHit(dmg);
    }

    private void ProcessHit(DamageDealer dmg) 
    {
        health -= dmg.GetDamage();

        dmg.Hit();

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(enemyDeathSound, Camera.main.transform.position, enemyDeathSoundVolume);
        //create an explosion particle using intintiate
        GameObject explosion = Instantiate(deathEffects, transform.position, Quaternion.identity);
        
        //destroy the particles after 1 sec
        Destroy(explosion, explosionDuaration);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Get a random number
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        // reduce time every frame
        shotCounter -= Time.deltaTime;

        if(shotCounter <= 0f)
        {
            //enemy shoots
            EnemyFire();
            // reset shot counter timer
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void EnemyFire()
    {
        GameObject laser = Instantiate(enemyLaserPrefab, transform.position, Quaternion.identity) as GameObject;
        // Give the laser a velocity in the Y-axis.
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-enemeyLaserSpeed);
        AudioSource.PlayClipAtPoint(enemyShootSound, Camera.main.transform.position, enemyShootSoundVolume);
    }
}
