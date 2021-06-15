using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraKontrol : MonoBehaviour
{
    public Transform Playertransform;
    [SerializeField] float minX, maxX;
    bool kitle;
    public GameObject target;
    public GameObject kitleme;

    // Start is called before the first frame update
    void Start()
    {
        kitle = false;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(Playertransform.position.x, minX, maxX), transform.position.y, transform.position.z);

        if (target.transform.position.x >= kitleme.transform.position.x )
        {
            transform.position = new Vector3(80, transform.position.y, transform.position.z);
            kitle = true;
        }
        else if (kitle == true)
        {
            transform.position = new Vector3(80, transform.position.y, transform.position.z);
        }
    }


      
    
}
