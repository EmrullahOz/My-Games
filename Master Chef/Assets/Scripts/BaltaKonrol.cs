using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaltaKonrol : MonoBehaviour
{
    public AudioSource baltaSes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Kasýk"))
        {
            baltaSes.Play();
        }

        if (collision.gameObject.CompareTag("Zemin"))
        {
            Destroy(gameObject);
        }
    }
}
