using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerKontrol : MonoBehaviour
{
    private float hýz = 200;
    private float TakýlmamaHýzý = 500f;
    private float Yukarýuc = 5f;

    public Text SkorYazýsý;

    public float ZýplamaGucu;

    public Rigidbody Player;

    public RectTransform Oksijen;
    public float OksijenSeviyesi;
    public float Oksijendusme = 100f;

    public AudioSource ZýpZýp;


    public float Zaman;

    // Start is called before the first frame update
    void Start()
    {
        OksijenSeviyesi = 100;
        Player = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Oksijendusme -= 6 * Time.deltaTime;

        OksijenSeviyesi = Oksijendusme;

        Oksijen.sizeDelta = new Vector2(OksijenSeviyesi, Oksijen.sizeDelta.y);

        Zaman += Time.deltaTime * 5;

        if (Zaman == 20)
        {
            hýz = 5000;
        }

        

        Player.AddForce(transform.forward*TakýlmamaHýzý);
        Player.AddForce(transform.up * Yukarýuc);


        if (Input.GetMouseButton(0))
        {
            Player.constraints = RigidbodyConstraints.FreezePositionY;
            Player.constraints = RigidbodyConstraints.FreezeRotation;
        }

        if (Oksijendusme <= 0)
        {
            SceneManager.LoadScene(2);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (Zaman >= 50)
        {
            hýz = 300f;
        }

        if (Zaman >= 200)
        {
            hýz = 1000f;
        }

        if (Zaman >= 300)
        {
            hýz = 2000f;
        }

        if (collision.gameObject.tag == "Gezegen")
        {
            Player.velocity = new Vector3(0f, ZýplamaGucu, hýz*Time.deltaTime);
            Oksijendusme += 10;
            Debug.Log("Gezegene trigger vurud");
            Debug.Log(collision.gameObject.name);

            ZýpZýp.Play();

        }

        if (collision.gameObject.tag == "Panel")
        {
            SceneManager.LoadScene(2);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Gezegen")
        {
            Player.velocity = new Vector3(0f, ZýplamaGucu, hýz * Time.deltaTime);
            
            Debug.Log("Gezegene stayde");

            ZýpZýp.Play();

        }
    }

    

    
}
