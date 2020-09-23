using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepScript : AsteroidScript
{
    Rigidbody step;

    public GameObject stepCap;

    float randomSpeed;
    float randomAngle;

    new float minSpeed = 30;
    new float maxSpeed = 45;
    public float rotationSpeed;


    new public void Start()
    {
        randomAngle = UnityEngine.Random.Range(-100, 100);
        randomSpeed = UnityEngine.Random.Range(minSpeed, maxSpeed);
        step = GetComponent<Rigidbody>();
        step.velocity = new Vector3(randomAngle, 0, -randomSpeed);
        step.angularVelocity = UnityEngine.Random.insideUnitSphere * rotationSpeed; // вращение вокруг оси
    }
    

    public override void OnTriggerEnter(Collider other)
    {
        // ничего не происходит при столкновении с:
        // List collide_ignored = { "Boudary", "asteroid", "step", "boss", "bosslazer" } 
        if (AsteroidScript.collide_ignored.Contains(other.tag))
        {
            return;
        }

        if (other.CompareTag("Player"))
        {
            PlayerScript.ScoreIncrease();
            Destroy(gameObject);
            Instantiate(asteroidExplosion, transform.position, Quaternion.identity);
            Instantiate(stepCap, transform.position, Quaternion.identity);
        }
        
    }

    public bool isNotBounced = true;

    public void Update()
    {
        
        bool isOutOfBoundary = transform.position.x < -50 || transform.position.x > 50;

        if (isOutOfBoundary && isNotBounced)
        {
            step.velocity = new Vector3((-1) * step.velocity.x, 0, -randomSpeed);
            isNotBounced = false;
        }

        if (!isOutOfBoundary)
        {
            isNotBounced = true;
        }
    }
}
