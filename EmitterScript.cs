using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterScript : MonoBehaviour
{
    public GameObject boss;

    public AsteroidScript asteroid;

    public StepScript step;

    bool IsBossSpawned = false;

    public float minDelayAsteroid, maxDelayAsteroid, minDelayStep, maxDelayStep; 
    float nextLaunchTimeAsteroid;
    float nextLaunchTimeStep;

    public static int delay_counter = 1;


    public static void RefreshCounter()
    {
        delay_counter = 1;
        
    }


    void spawner(AsteroidScript _object)
    {
        var positionY = -1.2f;
        var positionZ = transform.position.z;
        var positionX = UnityEngine.Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
        var newPosition = new Vector3(positionX, positionY, positionZ);
        Instantiate(_object, newPosition, Quaternion.identity);
    }
 

    public void update_delay(ref int counter)
    {
        if (counter == PlayerScript.GetPlayerScore())
        {
            return;
        }

        if (minDelayAsteroid > 0.05) // меньше 0.05 спавн уже ахуевший
        {
            minDelayAsteroid -= 0.05f; // мин значение задержки спавна астероидов
            maxDelayAsteroid -= 0.05f; // макс значение задержки спавна астероидов
            AsteroidScript.IncreaseAsteroidSpeed(5, 5); // скорость астероида
            //moveBack.IncreaseRoadSpeed(0.03f);   // раскомментировать если надо скорость дороги тоже увеличить
            ++counter;
        }
    }
   

    void Update()
    {
        if (PlayerScript.GetPlayerScore() == 10 && !IsBossSpawned)
        {
            Instantiate(
                    boss, 
                    new Vector3(transform.position.x, transform.position.y + 15,
                    transform.position.z),
                    Quaternion.identity);
            IsBossSpawned = true;
        }

        update_delay(ref delay_counter);

        if (Time.time > nextLaunchTimeAsteroid)
        {
            spawner(asteroid);
            nextLaunchTimeAsteroid = Time.time + UnityEngine.Random.Range(minDelayAsteroid, maxDelayAsteroid);
        }

        if (Time.time > nextLaunchTimeStep)
        {
            spawner(step);
            nextLaunchTimeStep = Time.time + UnityEngine.Random.Range(minDelayStep, maxDelayStep);
            
        }
    }
}