using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 targetDistance;
    public float camFollowDelta;
    public Transform target;
    public bool isFollow = true;

    void Start()
    {
        targetDistance = transform.position - target.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (isFollow )
            transform.position = new Vector3(transform.position.x,transform.position.y,targetDistance.z + target.transform.position.z);

    }
}
