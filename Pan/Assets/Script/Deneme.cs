using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deneme : MonoBehaviour
{

    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        //transform.position = Vector3.Lerp(transform.position, Player.transform.position * 3 * Time.deltaTime, 0.1f);

        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.Lerp(transform.position, Player.transform.position * 25 * Time.deltaTime, 1f);
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, 1f);




    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Sag"))
        {
            Destroy(gameObject);
            Debug.Log("DuVARRRRRRRRRRRRRRRRRRRRRRRRRRRR");


        }

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("CANNNNNNNNNNNNNNNNNNNN");
            Destroy(gameObject);


        }

        
    }
}
