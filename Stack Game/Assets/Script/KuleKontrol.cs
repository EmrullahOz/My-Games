using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KuleKontrol : MonoBehaviour
{
    public GameObject Kule;
    public float zaman = 0;
    public float sayac = 4;
   // public string Tamsayý;
    public float Scorum;

    public float fark;

    public Text GuncelSkor;
    // Start is called before the first frame update
    void Start()
    {
        fark = 0;
        Scorum = 0;

        PlayerPrefs.SetFloat("Puan", Scorum);

        //Tamsayý = Scorum.ToString("0.#");

        //GuncelSkor.text = Tamsayý.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void OnTriggerEnter(Collider other)
    {
        Scorum = PlayerPrefs.GetFloat("Puan");
        /*
        if (Scorum >= 5)
        {
            Kule.transform.position = new Vector3(Kule.transform.position.x, Kule.transform.position.y + 2f, Kule.transform.position.z);
        }*/
        fark = 0;

        if (sayac > 0 && Scorum >= 0)
        {

            InvokeRepeating("TasCýkma", 0.01f, 1f);


        }

    }

    private void OnTriggerStay(Collider other)
    {
        /*
        Scorum = PlayerPrefs.GetFloat("Puan");
        
        if (Scorum >= 5)
        {
            Kule.transform.position = new Vector3(Kule.transform.position.x, Kule.transform.position.y + 2f, Kule.transform.position.z);
        }
        
        if (sayac > 0 && Scorum >= 0)
        {
      
            InvokeRepeating("TasCýkma", 0.01f ,1f);

            Scorum = PlayerPrefs.GetFloat("Puan");
            Scorum = Scorum - 5;

            Tamsayý = Scorum.ToString("0.");

            PlayerPrefs.SetFloat("Puan", Scorum);

            GuncelSkor.text = Tamsayý.ToString();

        }

        */
        
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Cýktým");

        CancelInvoke("TasCýkma");
    }

    void TasCýkma()
    {
        float Calýstrmasayýsý = Scorum / 5;
        for (int i = 0; i < Calýstrmasayýsý; i++)
        {
            if (sayac >= 1 && Scorum >= 5)
            {
                Kule.transform.position = new Vector3(Kule.transform.position.x, Kule.transform.position.y + 2f, Kule.transform.position.z);
                sayac--;
                fark +=5;
                

                CancelInvoke("TasCýkma");

                Scorum = PlayerPrefs.GetFloat("Puan");
                Scorum = Scorum - 5;

                //Tamsayý = Scorum.ToString("0.");


                GuncelSkor.text = Scorum.ToString("#");

                PlayerPrefs.SetFloat("Puan", Scorum);

            }

        }                 
    }

}
