using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerKontrol : MonoBehaviour
{
    public float hýz;
    private Rigidbody rigi;

    public Animator anim;

    public Transform Kursun;

    public TextMeshProUGUI CanSayý;
    public float Caným;

    public GameObject Panel;

    public GameObject Dost1;
    public GameObject Dost2;
    public GameObject Dost3;

    public GameObject Close;



    public AudioSource DansSesi;


    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody>();

        CanSayý.text = Caným.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        rigi.velocity = new Vector3(0f, 0f, hýz * Time.deltaTime);

        if (Input.anyKey)
        {
            if (Input.mousePosition.x < Screen.width / 2)
            {
                anim.SetTrigger("sol");
            }
            if (Input.mousePosition.x > Screen.width / 2 )
            {
                if (Kursun.transform.position.x > 0)
                {
                    
                }
                anim.SetTrigger("sag");
            }

            
        }

        if (Caným <= 0)
        {
            anim.SetTrigger("Dead");
            SceneManager.LoadScene("Restart");
            Invoke("ZamanýDurdur", 3f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Kursun"))
        {
            Debug.Log("kursun vurdu");

            Caným--;

            CanSayý.text = Caným.ToString();

        }

        if (other.gameObject.CompareTag("Finish"))
        {
            anim.SetTrigger("Finish");
            Panel.gameObject.SetActive(true);
            Dost1.gameObject.SetActive(false);
            Dost2.gameObject.SetActive(false);
            Dost3.gameObject.SetActive(false);
            Close.gameObject.SetActive(false);


            DansSesi.Play();
            hýz = 0;

        }
    }

    void ZamanýDurdur()
    {
        Time.timeScale = 0;
    }

    public void SonSahne(string isim)
    {
        SceneManager.LoadScene(isim);
    }
}
