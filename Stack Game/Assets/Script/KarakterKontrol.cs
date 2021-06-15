using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KarakterKontrol : MonoBehaviour
{
    [SerializeField]
    int Hiz = 10;
    public Animator Myanimator;
    private Vector3 defaultlocalscale;
    public float Scorum;
    Rigidbody rb;

    public Animator Myanimation;

    public float puan;

    public Text TasSkor;

    public float sayac = 4;

    public BoxCollider Colliderým;

    public GameObject Tasým;
    public float Zamanlayýcý = 0;
    public GameObject Tas1;
    public GameObject Tas2;
    public GameObject Tas3;
    public GameObject Tas4;
    public GameObject Tas5;
    public GameObject Tas6;
    public GameObject Tas7;
    public GameObject Tas8;
    public GameObject Tas9;
    public GameObject Tas10;
    public GameObject Tas11;
    public GameObject Tas12;
    public GameObject Tas13;
    public GameObject Tas14;
    public GameObject Tas15;
    public GameObject Tas16;

    public KuleKontrol scor;
    public TasToplama TasSayý;
    float zaman = 0;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>(); ///fiziksel özellikleri alýnmýþ
        defaultlocalscale = transform.localScale;

        Scorum = PlayerPrefs.GetFloat("Puan");
    }

    // Update is called once per frame
    void Update()
    {

        float yatay = Input.GetAxis("Horizontal");

        float dikey = Input.GetAxis("Vertical");
      
       Vector3 hareket = new Vector3(yatay * Hiz, 0.0f, dikey * Hiz);   
       // rb.velocity = new Vector3(yatay * Hiz, 0.0f, dikey * Hiz);
        rb.AddForce(hareket);

       Myanimator.SetFloat("Hýz", Mathf.Abs(yatay));
       Myanimator.SetFloat("Hýzz", Mathf.Abs(dikey));



        if (yatay > 0)//karakterin yüzünün baktýðý yeri ayarlama
        {
            transform.localScale = new Vector3(defaultlocalscale.x, defaultlocalscale.y, defaultlocalscale.z);
            transform.localRotation = Quaternion.Euler(0, 90, 0);
        }
        else if (yatay < 0)
        {
            transform.localScale = new Vector3(-defaultlocalscale.x, defaultlocalscale.y, defaultlocalscale.z);
            transform.localRotation = Quaternion.Euler(0, -90, 0);
        }


        if (dikey > 0)//karakterin yüzünün baktýðý yeri ayarlama
        {
            transform.localScale = new Vector3(defaultlocalscale.x, defaultlocalscale.y, defaultlocalscale.z);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (dikey < 0)
        {
            transform.localScale = new Vector3(defaultlocalscale.x, defaultlocalscale.y, -defaultlocalscale.z);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        if (yatay > 0 && dikey > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 45, 0);
        }
        if (yatay < 0 && dikey > 0)
        {
            transform.localRotation = Quaternion.Euler(0, -45, 0);
        }
        if (yatay > 0 && dikey < 0)
        {
            transform.localRotation = Quaternion.Euler(0,-45 , 0);
        }
        if (yatay < 0 && dikey < 0)
        {
            transform.localRotation = Quaternion.Euler(0,45, 0);
        }

        Scorum = PlayerPrefs.GetFloat("Puan");

        if (Scorum == 5)
        {
            Tas1.SetActive(true);
        }
        if (Scorum < 5)
        {
            Tas1.SetActive(false);
        }

        if (Scorum == 10)
        {
            Tas2.SetActive(true);
        }
        if (Scorum < 10)
        {
            Tas2.SetActive(false);
        }

        if (Scorum == 15)
        {
            Tas3.SetActive(true);
        }
        if (Scorum < 15)
        {
            Tas3.SetActive(false);
        }

        if (Scorum == 20)
        {
            Tas4.SetActive(true);
        }
        if (Scorum < 20)
        {
            Tas4.SetActive(false);
        }

        if (Scorum == 25)
        {
            Tas5.SetActive(true);
        }
        if (Scorum < 25)
        {
            Tas5.SetActive(false);
        }

        if (Scorum == 30)
        {
            Tas6.SetActive(true);
        }
        if (Scorum < 30)
        {
            Tas6.SetActive(false);
        }

        if (Scorum == 35)
        {
            Tas7.SetActive(true);
        }
        if (Scorum < 35)
        {
            Tas7.SetActive(false);
        }

        if (Scorum == 40)
        {
            Tas8.SetActive(true);
        }
        if (Scorum < 40)
        {
            Tas8.SetActive(false);
        }

        if (Scorum == 45)
        {
            Tas9.SetActive(true);
        }
        if (Scorum < 45)
        {
            Tas9.SetActive(false);
        }

        if (Scorum == 50)
        {
            Tas10.SetActive(true);
        }
        if (Scorum < 50)
        {
            Tas10.SetActive(false);
        }

        if (Scorum == 55)
        {
            Tas11.SetActive(true);
        }
        if (Scorum < 55)
        {
            Tas11.SetActive(false);
        }

        if (Scorum == 60)
        {
            Tas12.SetActive(true);
        }
        if (Scorum < 60)
        {
            Tas12.SetActive(false);
        }

        if (Scorum == 65)
        {
            Tas13.SetActive(true);
        }
        if (Scorum < 65)
        {
            Tas13.SetActive(false);
        }

        if (Scorum == 70)
        {
            Tas14.SetActive(true);
        }
        if (Scorum < 70)
        {
            Tas14.SetActive(false);
        }

        if (Scorum == 75)
        {
            Tas15.SetActive(true);
        }
        if (Scorum < 75)
        {
            Tas15.SetActive(false);
        }

        if (Scorum == 80)
        {
            Tas16.SetActive(true);
        }
        if (Scorum < 80)
        {
            Tas16.SetActive(false);
        }
    }

    private void Tasssssopla()
    {
        

    }

    private void OnTriggerEnter(Collider other)
    {
       

        if (other.gameObject.CompareTag("Tas"))
        {
            Zamanlayýcý = 0;
            Zamanlayýcý += 20;
            zaman = other.GetComponent<TasToplama>().zaman;

            Myanimation.SetBool("Tas", true);

            InvokeRepeating("TasTopla", 1f , 1.5f);

            //puan -= scor.fark;
            //if (puan < 0)
            //{
            //    puan = 0;
            //}
            //TasSkor.text = puan.ToString("#");


        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (Myanimation.GetBool("Tas") == true)
        {
            Zamanlayýcý++;
            if (Zamanlayýcý % 80 == 0)
            {

                if (puan % 5 == 0)
                {
                    other.transform.localScale = new Vector3(other.transform.localScale.x - 0.01f, other.transform.localScale.y - 0.01f, other.transform.localScale.z - 0.01f);
                    other.GetComponent<BoxCollider>().size = new Vector3(other.GetComponent<BoxCollider>().size.x + 10, other.GetComponent<BoxCollider>().size.y, other.GetComponent<BoxCollider>().size.z + 8);

                    other.GetComponent<TasToplama>().zaman++;
                }

                if (other.GetComponent<TasToplama>().zaman == 4)
                {
                    other.GetComponent<BoxCollider>().size = new Vector3(other.GetComponent<BoxCollider>().size.x + 10, other.GetComponent<BoxCollider>().size.y, other.GetComponent<BoxCollider>().size.z + 8);

                }

                if (other.GetComponent<TasToplama>().zaman == 5)
                {
                    Destroy(other.gameObject, 0.2f);
                    Myanimation.SetBool("Tas", false);
                    CancelInvoke("TasTopla");
                }
            }
        }

        if (Myanimation.GetBool("Tas") == false)
        {
            Debug.Log("PATATESSSSSSSSSS");

            CancelInvoke("TasTopla");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Tas"))
        {
            Myanimation.SetBool("Tas",false);

            Debug.Log("Yok oldu");

            CancelInvoke("TasTopla");
        }


        if (other.gameObject.CompareTag("Zemin") )
        {
            if (scor.sayac==0)
            {
                puan -= scor.fark;
                if (puan < 0)
                {
                    puan = 0;
                }
                TasSkor.text = puan.ToString("#");
                sayac--;
            }
            else if (scor.sayac>0)
            {
                puan -= scor.fark;
                if (puan < 0)
                {
                    puan = 0;
                }
                TasSkor.text = puan.ToString("#");
            }
            //puan -= scor.fark;
            //if (puan < 0)
            //{
            //    puan = 0;
            //}
            //TasSkor.text = puan.ToString("#");
        }

    }

    private void TasTopla()
    {
        puan = puan + 5;


        PlayerPrefs.SetFloat("Puan", puan);

        TasSkor.text = puan.ToString("#");

    }
}
