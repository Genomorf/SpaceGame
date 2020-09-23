using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerScript : MonoBehaviour
{
    public GameObject playerExplosion;
    public GameObject lazerShot;

    Rigidbody player;

    public Transform lazerGun1, lazerGun2, lazerGun3;
    
    
    public float lazer_time = 10f;
    public float shotDelay;
    public float speed;
    public float XMIN, XMAX, ZMIN, ZMAX;
    public float TILT;
    
    float nextShotTime;
    
    public Text text;
   
    public Image healthImage;

    private static int PlayerHealth = 1000;
    private static int score = 1;


    void Start()
    {
        player = GetComponent<Rigidbody>();
        InvokeRepeating("Fire", lazer_time, lazer_time);
    }
    
    public void Fire()
    {
        GameObject obj = ObjectPooler.current.GetPooledObject();
        
        if (obj == null) return;
        obj.transform.position = transform.position;
        
        obj.SetActive(true);
    }

    public static int GetPlayerScore() { return score; }

    public static int GetPlayerHealth() { return PlayerHealth; }

    public static void HealthDecrease() { --PlayerHealth; }

    public static void ScoreIncrease() { ++score; }


    public static bool IsDead()
    {
        if (PlayerHealth <= 0)
            return true;
        return false;
    }


    public static void RefreshStats()
    {
        PlayerHealth = 3;
        score = 1;
    }

    /*
    void upgrade_guns(int number_of_guns = 1, int lazer_speed = 20, float shotdelay = 1f)
    {
        // устанавливаем тут глобальные переменные: задержку между выстрелами и скорость снаряда
        shotDelay = shotdelay;
        LaserScript.lazer_speed = lazer_speed;

        // создаем объекты в игре в зависимости от количества пушек
        switch (number_of_guns)
        {
            case 1:
                Instantiate(lazerShot, lazerGun3.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(lazerShot, lazerGun1.position, Quaternion.identity);
                Instantiate(lazerShot, lazerGun2.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(lazerShot, lazerGun1.position, Quaternion.identity);
                Instantiate(lazerShot, lazerGun2.position, Quaternion.identity);
                Instantiate(lazerShot, lazerGun3.position, Quaternion.identity);
                break;
        }
    }

    // стреляем 
    void fire()
    {
        switch (score)
        {
            case 1:
                upgrade_guns(); // 1 пушка и стандартный режим огня
                break;
            case 2:
                upgrade_guns(1, 30, 0.8f); // 1 пушка, но стреляем быстрее
                break;
            case 3:
                upgrade_guns(2, 20, 1f); // 2 пушки и стандартный режим 
                break;
            case 4:
                upgrade_guns(2, 30, 0.8f); // 2 пушки, но стреляем быстрее 
                break;
            case 5:
                upgrade_guns(3, 20, 1f); // и так далее пока не будет 3 пушки и макс скорость атаки
                break;
            default:
                upgrade_guns(3, 30, 0.8f);
                break;
        }
    }*/


    void Update()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        player.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;

        var clampedX = Mathf.Clamp(player.position.x, XMIN, XMAX);
        var clampedZ = Mathf.Clamp(player.position.z, ZMIN, ZMAX);

        player.position = new Vector3(clampedX, 0, clampedZ);
        player.rotation = Quaternion.Euler(TILT * player.velocity.z, 0, -TILT * player.velocity.x);

        text.text = string.Format("Score {0}", (score - 1).ToString());
        /*
        if (Time.time > nextShotTime)
        {
            fire();
            nextShotTime = Time.time + shotDelay;
        }
        */
     
        if (PlayerScript.IsDead())
        {
            Destroy(gameObject);
            Instantiate(playerExplosion, transform.position, Quaternion.identity);
            SceneManager.LoadScene("retry");
            PlayerScript.RefreshStats();
            EmitterScript.RefreshCounter();
            AsteroidScript.RefreshSpeed();
            moveBack.RefreshRoadSpeed();
        }
    }

}