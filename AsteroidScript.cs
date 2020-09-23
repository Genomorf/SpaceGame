using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AsteroidScript : MonoBehaviour
{
    
    Rigidbody asteroid;

    public GameObject asteroid2;
    public GameObject asteroidExplosion;

    public static float minSpeed = 40, maxSpeed = 60;

    public static List<string> collide_ignored =
        new List<string> { "Boudary", "asteroid", "step", "boss", "bosslazer" };
   
    
    public static void RefreshSpeed()
    {
        minSpeed = 40;
        maxSpeed = 60;
    }


    public static void IncreaseAsteroidSpeed(int min_value, int max_value)
    {
        minSpeed += min_value;
        maxSpeed += max_value;
    }


    public void Start()
    {
        asteroid = GetComponent<Rigidbody>();
        var randomSpeed = UnityEngine.Random.Range(minSpeed, maxSpeed);
        asteroid.velocity = new Vector3(0, 0, -randomSpeed);
    }

    
    public virtual void OnTriggerEnter(Collider other)   
    {   
        if (collide_ignored.Contains(other.tag))
        {
            return;
        }

        Destroy(gameObject);

        Instantiate(asteroidExplosion, transform.position, Quaternion.identity);
        Instantiate(asteroid2, transform.position, Quaternion.identity);
        
      
        if (other.CompareTag("Player"))
        {
            PlayerScript.HealthDecrease();            
        }
    }
}
