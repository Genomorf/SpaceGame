using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// удаляем объекты за экраном
public class BoundaryScript : MonoBehaviour
{
    private void OnTriggerExit (Collider other)
    { 
        if (other.CompareTag("road"))
            return;
        Destroy(other.gameObject);
    }

}
