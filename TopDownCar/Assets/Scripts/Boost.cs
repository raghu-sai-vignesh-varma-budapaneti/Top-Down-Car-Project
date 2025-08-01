using UnityEngine;
using System.Collections;

public class SpeedBoostZone2D : MonoBehaviour
{
    [Header("Boost Settings")]
    public float boostMultiplier = 2f;         // 2x the current speed
    public float boostDuration = 10f;          // Duration in seconds

    private bool hasActivated = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasActivated) return;

        CarController car = other.GetComponent<CarController>();
        if (car != null)
        {
            hasActivated = true;

            float boostedSpeed = car.GetCurrentSpeed() * boostMultiplier;
            car.SetBoostedSpeed(boostedSpeed);

            Debug.Log("Speed Boost Activated for " + boostDuration + " seconds");

            StartCoroutine(BoostCountdown(car));
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

        Destroy(gameObject); // Destroy only after boost ends
    }
}
