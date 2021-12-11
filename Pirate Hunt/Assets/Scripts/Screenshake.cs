using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshake : MonoBehaviour
{
    public static float ShakeAmount = 0;
    Vector3 StartingPosition;

    void Start()
    {
        StartingPosition = transform.position;
    }

    void Update()
    {
        // Shake Camera
        ShakeAmount = Mathf.Lerp(ShakeAmount, 0, 0.08f);
        transform.position = StartingPosition + Random.onUnitSphere * ShakeAmount;
    }
}
