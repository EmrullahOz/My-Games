using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TasToplama : MonoBehaviour
{
    public BoxCollider Colliderým;
    public Animator Myanimation;

    public int zaman;

    public KarakterKontrol puann;


    private void OnTriggerEnter(Collider other)
    {

       // InvokeRepeating("TasToplaa", 1f, 1.5f);

    }

    private void OnTriggerExit(Collider other)
    {
        Myanimation.SetBool("Tas", false);
    }


    private void TasToplaa()
    {
        Debug.Log("Toplandý");

        if (Myanimation.GetBool("Tas") == true)
        {

            if (puann.puan % 5 == 0)
            {
              //  transform.localScale = new Vector3(transform.localScale.x - 0.01f, transform.localScale.y - 0.01f, transform.localScale.z - 0.01f);
               // Colliderým.size = new Vector3(Colliderým.size.x + 10, Colliderým.size.y, Colliderým.size.z + 8);
                //zaman++;
            }

            if (zaman == 4)
            {
              //  Colliderým.size = new Vector3(Colliderým.size.x + 10, Colliderým.size.y, Colliderým.size.z + 8);
            }

            if (zaman == 5)
            {
                Destroy(gameObject, 0.2f);
                Myanimation.SetBool("Tas", false);

            }
        }


    }

}
