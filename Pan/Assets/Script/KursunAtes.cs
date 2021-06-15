using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KursunAtes : MonoBehaviour
{
    public Rigidbody kursunrigi;
    public GameObject Playeryer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ates();
    }

    public void Ates()
    {
        kursunrigi.AddForce(Playeryer.transform.position, ForceMode.Impulse);
        
    }
}
