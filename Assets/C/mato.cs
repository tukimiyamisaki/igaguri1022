using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public igaguri gameManager; 

    void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Projectile")) 
        {
            gameManager.AddScore(10); 
            Destroy(other.gameObject); 
        }
    }
}