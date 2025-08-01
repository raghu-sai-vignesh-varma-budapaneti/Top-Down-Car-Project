using System;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float rotationSpeed = 200f;   // Set this in Inspector
    public float moveSpeed = 5f;         // Default speed, editable in Inspector
    public Transform cartransform;

    [SerializeField] private float currentSpeed;

    void Start()
    {
        currentSpeed = moveSpeed;
    }

    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        if (Math.Abs(horizontalMovement) > 0.01f)
        {
            cartransform.Rotate(0f, 0f, -rotationSpeed * horizontalMovement * Time.deltaTime);
        }

        if (Math.Abs(verticalMovement) > 0.01f)
        {
            cartransform.Translate(0f, currentSpeed * verticalMovement * Time.deltaTime, 0f);
        }
    }

    public void SetBoostedSpeed(float boostedSpeed)
    {
        currentSpeed = boostedSpeed;
        Debug.Log("Speed boosted to: " + currentSpeed);
    }

    public void ResetSpeed()
    {
        currentSpeed = moveSpeed;
        Debug.Log("Speed reset to: " + currentSpeed);
    }

    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }
}
