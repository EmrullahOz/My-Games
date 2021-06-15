using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenkDuvarı : MonoBehaviour
{
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.GetComponent<Renderer>().material.color==Color.red )
        {
            Player.gameObject.GetComponent<Renderer>().material.color =Color.red;
        }
        if (gameObject.GetComponent<Renderer>().material.color == Color.blue)
        {
            Player.gameObject.GetComponent<Renderer>().material.color =Color.blue;
        }
        if (gameObject.GetComponent<Renderer>().material.color == Color.yellow)
        {
            Player.gameObject.GetComponent<Renderer>().material.color =Color.yellow;
        }
    }

}
