using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SagDuvar : MonoBehaviour
{
    public float hýz;
    private Rigidbody rigi;
    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rigi.velocity = new Vector3(0f, 0f, hýz * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Kursun"))
        {
            Destroy(other.gameObject);
            Debug.Log("kursun vurdu");
           

        }
    }
}
