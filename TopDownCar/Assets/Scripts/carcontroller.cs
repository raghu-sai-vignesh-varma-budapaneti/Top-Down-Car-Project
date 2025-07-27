using System;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float rotationSpeed, moveSpeed;
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

        // Debug.Log("horizontal:" + horizontalMovement + " vertical:" + verticalMovement);

        if (Math.Abs(horizontalMovement) > 0.01f)
        {
            cartransform.Rotate(0f, 0f, -1 * rotationSpeed * horizontalMovement);
        }
        if (Math.Abs(verticalMovement) > 0.01f)
        {
            cartransform.Translate(0f, currentSpeed * verticalMovement, 0f);
        }
    }

    public void SetBoostedSpeed(float boostedSpeed)
    {
        currentSpeed = boostedSpeed;
    }

    public void ResetSpeed()
    {
        currentSpeed = moveSpeed;
    }
}
