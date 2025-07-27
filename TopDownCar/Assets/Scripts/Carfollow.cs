using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carfollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform carTransform;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // Directly match camera's X and Y to the car
        float carX = carTransform.position.x;
        float carY = carTransform.position.y;

        // Set Z manually to -10 (for 2D view)
        transform.position = new Vector3(carX, carY, -10f);

    }
}
