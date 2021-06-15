using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IcdekiColl : MonoBehaviour
{
    public TextMeshProUGUI Perfect;
    public TextMeshProUGUI puan;
    public Animator Altýn;
    private float altýnsayý = 0;
    public GameObject Dusman;

   public AudioSource TavaSesi;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        puan.text = altýnsayý.ToString();
    }

    private void OnTriggerStay(Collider other)
    {
       

        if (Input.anyKey)
        {
            if (Input.mousePosition.x < Screen.width / 2)
            {
                for (int i = 0; i < 1; i++)
                {
                    altýnsayý++;
                }
                Perfect.gameObject.SetActive(true);
                Altýn.SetTrigger("Altýn");

               // puan.text = altýnsayý.ToString();
                Dusman.gameObject.SetActive(false);
               TavaSesi.Play();

                Debug.Log("Perfect");
            }

            if (Input.mousePosition.x > Screen.width / 2)
            {
                for (int i = 0; i < 1; i++)
                {
                    altýnsayý++;
                }
                Perfect.gameObject.SetActive(true);
                Altýn.SetTrigger("Altýn");
                
                puan.text = altýnsayý.ToString();
                Dusman.gameObject.SetActive(false);
                TavaSesi.Play();
                Debug.Log("Perfect");
            }


        }
    }

    private void OnTriggerExit(Collider other)
    {
        Perfect.gameObject.SetActive(false);
    }
}
