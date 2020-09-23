using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    public GameObject BossExplosion;
    public GameObject lazerShot;
    public GameObject explosion;

    Rigidbody boss_body;

    public AsteroidScript asteroid;

    public static int boss_health = 150;

    public float speed;
    public float shotDelay;
    float nextShotTime;


    void Start()
    {
        boss_body = GetComponent<Rigidbody>();
    }


    public bool IsBossDead()
    {
        if (boss_health < 0)
            return true;
        return false;
    }


    public void boss_hit()
    {
        --boss_health;
        
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bosslazer") || other.CompareTag("asteroid")) return;

        if (other.CompareTag("lazer"))
        {
            boss_hit();
            Instantiate(explosion, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
    }


    void spawner(AsteroidScript _object)
    {
        for (int i = 0; i < 25; ++i)
            Instantiate(
                _object, 
                new Vector3(boss_body.position.x - UnityEngine.Random.Range(-10, 10),
                boss_body.position.y, boss_body.position.z-20),
                Quaternion.identity);
    }


    void Update()
    {
        if (transform.position.z > 50)
        {
            transform.Translate(0, 0, 0.1f);
        }

        if (Time.time > nextShotTime)
        {
            Instantiate(
                lazerShot, 
                new Vector3(boss_body.position.x, boss_body.position.y, boss_body.position.z),
                Quaternion.identity);
            spawner(asteroid);
            nextShotTime = Time.time + shotDelay;
        }

        transform.Translate(speed, 0, 0);
        if (transform.position.x < -50 || transform.position.x > 50)
            speed *= -1;
        
        if (IsBossDead())
        {
            Destroy(gameObject);
            for (int i = 0; i < 5; ++i)
                Instantiate(BossExplosion, transform.position, Quaternion.identity);
        }
    }
}
