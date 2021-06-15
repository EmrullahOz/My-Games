using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnRenkDuvarı : MonoBehaviour
{
    public GameObject Player;
    public GameObject RenkDuvari;

    private void OnTriggerEnter(Collider other)
    {
        if (Player.gameObject.GetComponent<Renderer>().material.color == Color.red)
        {
            int sayi = Random.Range(0, 2);
            if (sayi == 0)
            {
                RenkDuvari.gameObject.GetComponent<Renderer>().material.color = Color.blue;
            }
            else if (sayi == 1)
            {
                RenkDuvari.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            }
        }
        if (Player.gameObject.GetComponent<Renderer>().material.color == Color.blue)
        {
            int sayi = Random.Range(0, 2);
            if (sayi == 0)
            {
                RenkDuvari.gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
            else if (sayi == 1)
            {
                RenkDuvari.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            }
        }
        if (Player.gameObject.GetComponent<Renderer>().material.color == Color.yellow)
        {
            int sayi = Random.Range(0, 2);
            if (sayi == 0)
            {
                RenkDuvari.gameObject.GetComponent<Renderer>().material.color = Color.blue;
            }
            else if (sayi == 1)
            {
                RenkDuvari.gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }
}
