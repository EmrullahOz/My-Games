using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public float hiz;
    Rigidbody rigi;

    public Transform zemin1;
    public Transform zemin2;

    public Duvarlar duvar;

    float puan =0;
    public Text puanText;
    public Text sonucText;

    public GameObject tekrarPaneli;
    public GameObject PuanPaneli;

    public GameObject Music;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        rigi = GetComponent<Rigidbody>();
        Music.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        rigi.velocity=new Vector3(0, 0, hiz);
        //rigi.AddForce(0, 0, 1f*Time.deltaTime);

        //transform.Translate( 0, 0, hiz * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x!=3)
        {
            transform.Translate(3f, 0, hiz * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x != -3)
        {
            transform.Translate(-3f, 0, hiz * Time.deltaTime);
        }

        puan += Time.deltaTime*10;
        puanText.text = puan.ToString("#");
        if (puan % 100 <=Time.deltaTime*10 )
        {
            hiz += 1f;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name=="Son1")
        {
            zemin2.position = new Vector3(zemin1.position.x, zemin1.position.y, zemin1.position.z + 100f);
            duvar.KlonOlusturma();
        }
        if (other.gameObject.name == "Son2")
        {
            zemin1.position = new Vector3(zemin2.position.x, zemin2.position.y, zemin2.position.z + 100f);
            duvar.KlonOlusturma();

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Duvar"))
        {
            if (gameObject.GetComponent<Renderer>().material.color == collision.gameObject.GetComponent<Renderer>().material.color)
            {
                collision.gameObject.SetActive(false);
            }
            else
            {
                tekrarPaneli.SetActive(true);
                sonucText.text = puan.ToString("#");
                Time.timeScale = 0;
                PuanPaneli.SetActive(false);
                Music.SetActive(false);
                puan = 0;
            }
        }
        
    }
}
