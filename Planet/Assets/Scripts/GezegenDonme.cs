using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GezegenDonme : MonoBehaviour
{
    public float speed = 50;
    private Vector3 rotateVector;
    // Start is called before the first frame update
    void Start()
    {
        
    rotateVector = new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotateVector * speed * Time.fixedDeltaTime);
    }
}
