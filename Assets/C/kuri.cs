using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class igaguri : MonoBehaviour
{
    public GameObject objectToThrow; 
    public float throwForce = 10f;   
    private Camera mainCamera;
    private int score = 0;         

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
       
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 throwDirection = (hit.point - transform.position).normalized;

           
            if (Input.GetKeyDown(KeyCode.E))
            {
                Throw(throwDirection);
            }
        }
    }

    void Throw(Vector3 direction)
    {
        
        GameObject thrownObject = Instantiate(objectToThrow, transform.position, Quaternion.identity);
        Rigidbody rb = thrownObject.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(direction * throwForce, ForceMode.Impulse);
        }
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Score: " + score);
    }
}