using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{

    public static float lazer_speed = 40;
    public float rotationSpeed = 10f;
    public bool isDestroyed = false;
    public static Rigidbody lazer;

    public static float GetSpeed() { return lazer_speed; }

    void Start()
    {
        lazer = GetComponent<Rigidbody>();
        lazer.velocity = new Vector3(0, 0, lazer_speed);
        lazer.angularVelocity = UnityEngine.Random.insideUnitSphere * rotationSpeed;
        
    }

    private void OnEnable()
    {
        Invoke("Destroy", 3f);
        
    }


    void Destroy()
    {
        gameObject.SetActive(false);

    }

    private void OnDisable()
    {
        CancelInvoke();
    }
    
    public virtual void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.TryGetComponent<AsteroidScript>(out var asteroid))
        {
            Destroy(); 
        }
    }


}
