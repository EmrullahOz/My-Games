using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KasıkKontrol : MonoBehaviour
{
    public AudioSource carpısma;
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
        if (collision.gameObject.CompareTag("Dusman1"))
        {

            Destroy(gameObject);
            Debug.Log("vurdu");

        }

        if (collision.gameObject.CompareTag("Balta"))
        {

            Destroy(gameObject);
            Destroy(collision.gameObject);


            carpısma.Play();


        }

        if (collision.gameObject.CompareTag("Zemin"))
        {
            Destroy(gameObject);
        }
    }
}
