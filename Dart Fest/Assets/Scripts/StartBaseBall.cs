using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBaseBall : MonoBehaviour
{
    public static StartBaseBall instance;

    public bool startOn = false;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StartOn"))
        {
            startOn = false;
        }
    }
}
