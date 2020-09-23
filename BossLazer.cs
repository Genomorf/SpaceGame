using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_lazer : MonoBehaviour
{
    public GameObject explosion;
    public GameObject SecLazer;
    Transform _transform;
    Rigidbody lazer;

    float lazer_speed = 100;


    void Start()
    {
        lazer = GetComponent<Rigidbody>();
        lazer.velocity = new Vector3(0, 0, -lazer_speed);
        _transform = transform;
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("boss") || other.CompareTag("asteroid"))
            return;
        if (other.CompareTag("Player"))
        {
            PlayerScript.HealthDecrease();
        }
    }


    void Update()
    {
        if (_transform.position.z < -40)
        {
            Instantiate(explosion, _transform.position, Quaternion.identity);
            Instantiate(SecLazer, _transform.position, Quaternion.identity);
        }
        _transform.Rotate(new Vector3(0, 0.05f, 0));
    }
}
