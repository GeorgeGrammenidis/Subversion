using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public bool moveBackAndForth = true; 
    public float moveSpeed = 2f; 
    public Vector3 startPosition;
    public Vector3 endPosition;

   
    public bool rotateAroundSelf = false; 
    public float rotationSpeed = 50f; 

    private bool movingToEnd = true; 

    void Start()
    {
        if (moveBackAndForth)
        {
            transform.position = startPosition;
        }
        
    }

    void Update()
    {
        if (moveBackAndForth)
        {
            MovePlatform();
        }

        if (rotateAroundSelf)
        {
            RotatePlatform();
        }
    }

    void MovePlatform()
    {
        Vector3 targetPosition = movingToEnd ? endPosition : startPosition;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            movingToEnd = !movingToEnd; 
        }
    }

    void RotatePlatform()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
