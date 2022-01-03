using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControl : MonoBehaviour
{
    [SerializeField] int _speedRotate;

    void Start()
    {
        
    }

    void Update()
    {
        transform.RotateAround(transform.position, new Vector3(0, 360, 0), _speedRotate * Time.deltaTime);
    }
}
