using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakip : MonoBehaviour
{
    public GameObject hedef;
    public Vector3 mesafe;
    public int speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, hedef.transform.position + mesafe,speed* Time.deltaTime);
    }
}
