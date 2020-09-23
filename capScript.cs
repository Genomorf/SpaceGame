using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capScript : MonoBehaviour
{
    Rigidbody cap;

    float randomSpeedx;
    float randomSpeedz;


    void Start()
    {
        randomSpeedx = Random.Range(-10, 10);
        randomSpeedz = Random.Range(-10, 10);

        cap = GetComponent<Rigidbody>();
        cap.velocity = new Vector3(randomSpeedx, -10, randomSpeedz);
        cap.angularVelocity = UnityEngine.Random.insideUnitSphere * 10;
    }

}
