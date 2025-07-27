using UnityEngine;
using System.Collections;

public class SpeedBoostZone2D : MonoBehaviour
{
    public float boostSpeed = 0.1f;
    public float boostDuration = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        CarController car = other.GetComponent<CarController>();
        if (car != null)
        {
            car.SetBoostedSpeed(boostSpeed);
            Debug.Log("Speed Boost Activated for " + boostDuration + " seconds");

            StartCoroutine(BoostCountdown(car));
            Destroy(gameObject); // prevent re-use
        }
    }

    private IEnumerator BoostCountdown(CarController car)
    {
        float timeLeft = boostDuration;

        while (timeLeft > 0)
        {
            Debug.Log("Boost time remaining: " + timeLeft + " seconds");
            yield return new WaitForSeconds(1f);
            timeLeft -= 1f;
        }

        car.ResetSpeed();
        Debug.Log("Speed Boost Deactivated");
    }
}
