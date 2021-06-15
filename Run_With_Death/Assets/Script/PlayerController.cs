using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float hiz;
    Rigidbody rigi;
    public int stack = 2;
    
    public float jumpPower ;
    public bool Grounded;

    public GameObject ruh;

    public float can;
    public Text canText;
    public float puan;
    public Text puanText;

    public Animator anim;

    public float zaman;
    public Text zamanText;

    public GameObject PanelPause2;

    public AudioClip engelMusic;
    public AudioClip goldMusic;

    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
        ruh.gameObject.SetActive(false);
        canText.text = can.ToString();
        puanText.text = puan.ToString();
        zamanText.text = zaman.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Grounded = true;

        if (collision.gameObject.CompareTag("Engel"))
        {
            AudioSource.PlayClipAtPoint(engelMusic, transform.position);
            ruh.gameObject.SetActive(true);
            Invoke("RuhCýkma", 2f);
            hiz++;
            can -= 10;
            canText.text = can.ToString();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Engel"))
        {
            AudioSource.PlayClipAtPoint(engelMusic, transform.position);
            ruh.gameObject.SetActive(true);
            Invoke("RuhCýkma", 2f);
            hiz++;
            can -= 10;
            canText.text = can.ToString();
        }

        if (other.gameObject.CompareTag("Gold"))
        {
            AudioSource.PlayClipAtPoint(goldMusic, transform.position);
            Destroy(other.gameObject);
            hiz--;
            can +=5;
            canText.text = can.ToString();
            puan += 10;
            puanText.text = puan.ToString();
        }

        if (other.gameObject.CompareTag("Ok"))
        {
            AudioSource.PlayClipAtPoint(engelMusic, transform.position);
            ruh.gameObject.SetActive(true);
            Invoke("RuhCýkma", 2f);
            Destroy(other.gameObject);
            hiz++;
            can -= 10;
            canText.text = can.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        zaman -= Time.deltaTime;
        zamanText.text =zaman.ToString("#");

        transform.Translate(0, 0, hiz * Time.deltaTime);
        //rigi.AddForce(new Vector3(0, 0, hiz*Time.deltaTime), ForceMode.Impulse);
        //rigi.velocity = new Vector3(0, 0, hiz);

        if (Input.GetKeyDown(KeyCode.RightArrow) && stack<3)
        {
            transform.Translate(1f, 0, hiz * Time.deltaTime);
            stack++;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && stack>1)
        {
            transform.Translate(-1f, 0, hiz * Time.deltaTime);
            stack--;
        }

        if (Input.GetKeyDown(KeyCode.Space) && Grounded==true)
        {

            //rigi.velocity = Vector3.up * jumpPower * Time.deltaTime;
            
            rigi.AddForce(new Vector3(0, jumpPower, hiz * Time.deltaTime*3),ForceMode.Impulse);
           
            Debug.Log("yere deðdi");
            Grounded = false;
            
        }
        if (can<=0 || zaman<=0)
        {
            zaman = 0;
            canText.text = can.ToString();

            Invoke("Hiz", 0.3f);
            Invoke("Die", 0.05f);
            Invoke("Panel2", 2f);
            
        }

    }

    void Hiz()
    {
        hiz = 0;
    }
    void Die()
    {
        anim.SetTrigger("Die");
    }
    void Panel2()
    {
        PanelPause2.SetActive(true);
    }

     void RuhCýkma()
    {
        ruh.gameObject.SetActive(false);
    }
}
