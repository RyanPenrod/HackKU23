using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowDirection : MonoBehaviour
{
    public float maxRotationAngle = 45f;
    public float rotationSpeed = 5f;
    private Quaternion initialRotation;
    private Quaternion targetRotation;

    private void Start()
    {
        initialRotation = transform.rotation;
        targetRotation = initialRotation;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            targetRotation = initialRotation * Quaternion.Euler(0f, 0f, -maxRotationAngle);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            targetRotation = initialRotation * Quaternion.Euler(0f, 0f, maxRotationAngle);
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
