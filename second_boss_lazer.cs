using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class second_boss_lazer : LaserScript
{
    // Start is called before the first frame update
    Rigidbody lazer;
    new  float lazer_speed = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        float random_value = (UnityEngine.Random.Range(1, 3));
        lazer = GetComponent<Rigidbody>();
        switch (random_value)
        {
            case 1:
                lazer.velocity = new Vector3(lazer_speed, 0, 0);
                break;
            case 2:
                lazer.velocity = new Vector3(-lazer_speed, 0, 0);
                break;
        }
    }/*
    public override void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            PlayerScript.HealthDecrease();
        }
    }*/
   
}
