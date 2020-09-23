using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid2Script : MonoBehaviour
{
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3 (0, 0, PlayerScript.GetPlayerScore() * -3);
    }
}
