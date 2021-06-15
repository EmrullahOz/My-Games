using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanKontrol : MonoBehaviour
{
    public GameObject dusman;
    public GameObject Mermi;


    public GameObject kursun;
    public Transform Konum;

    public Transform Player;

    public Rigidbody KursunRigi;

    public Animator anim;
    public Animator Mermianim;


    public GameObject Sag;
    public GameObject Sol;

    public GameObject SagDuvar;
    public GameObject SolDuvar;

    public AudioSource SilahSesi;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }


    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("kup dog");
            dusman.gameObject.SetActive(true);
            Invoke("MermiAtýs", 1.5f);
            
            // kursun.transform.position = Vector3.Lerp(kursun.transform.position,Player.transform.position,20f - 20f);       

        }

        SilahSesi.Play();
        if (dusman.transform.position.x > 0)
        {
            Sag.gameObject.SetActive(true);
            Debug.Log("Dusman Sagda");
        }

        if (dusman.transform.position.x < 0)
        {
            Sol.gameObject.SetActive(true);

            Debug.Log("Dusman Solda");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Mermianim.SetTrigger("Fire");
        if (Input.anyKey)
        {
            if (Input.mousePosition.x < Screen.width / 2)
            {
                
                

                SolDuvar.gameObject.SetActive(true);
                SagDuvar.gameObject.SetActive(false);

                Debug.Log("Sol Duvar");
                anim.SetTrigger("sol");
            }
            if (Input.mousePosition.x > Screen.width / 2)
            {
                

                SagDuvar.gameObject.SetActive(true);
                SolDuvar.gameObject.SetActive(false);
                Debug.Log("Sag duvar cýktý");
                anim.SetTrigger("sag");
            }


        }
    }

    private void OnTriggerExit(Collider other)
    {
        Sol.gameObject.SetActive(false);
        Sag.gameObject.SetActive(false);



        if (other.gameObject.CompareTag("Player"))
        {

           // kursun.transform.position = Vector3.Lerp(kursun.transform.position, Player.transform.position, 20f - 20f);
         // kursun.transform.position = Player.position;
            
            //  kursun.transform.position = Vector3.Lerp(kursun.transform.position, Player.transform.position, 20f);
            Debug.Log("kursun cýksýn");
        }
    }

    
   public void MermiAtýs()
    {
        Mermi.gameObject.SetActive(true);
        SilahSesi.Play();
    }

    public void SagDuvarAktif()
    {
        SagDuvar.gameObject.SetActive(false);
    }

    public void SolDuvarAktif()
    {
        SolDuvar.gameObject.SetActive(false);
    }
}
