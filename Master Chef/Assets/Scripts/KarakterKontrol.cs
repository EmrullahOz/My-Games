using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KarakterKontrol : MonoBehaviour
{
    public float can;
    public float zýplamaSeviye;
    public TextMeshProUGUI kalp;
    public Rigidbody2D rg;
    public float hiz;
    private bool havada;
    public float yatay;
    private Vector3 defaultlocalscale;
    public GameObject Kasýk;
    public Animator MyAnimation;
    bool attackAnimasyon;
    [SerializeField] float currenttimerattack;
    [SerializeField] float defaulttimerattack;
    private Vector3 yon;
    bool attack;
    public AudioSource kasýkSes;
    public AudioSource baltaSes;


    // Start is called before the first frame update
    void Start()
    {
        kalp.text = can.ToString();
        yon = new Vector3(0.5f,0,0);
        attack = false;
        havada = true;
        defaultlocalscale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        Zipla();
        yatay = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(yatay, 0f, 0f);
        transform.position += movement * Time.deltaTime * hiz;

        if (yatay > 0)//karakterin yüzünün baktýðý yeri ayarlama
        {
            transform.localScale = new Vector3(defaultlocalscale.x, defaultlocalscale.y, defaultlocalscale.z);
            MyAnimation.SetTrigger("walk");
        }
        else if (yatay < 0)
        {
            transform.localScale = new Vector3(-defaultlocalscale.x, defaultlocalscale.y, defaultlocalscale.z);
            MyAnimation.SetTrigger("walk");
        }

        if (Input.GetMouseButtonDown(0) && attack == false)
        {
           MyAnimation.SetTrigger("AttackR");
           MyAnimation.SetTrigger("AttackL");

           Invoke("Fire", 0.5f);
           attack = true;
        }

        if (attack == true)
        {
            currenttimerattack -= Time.deltaTime;
        }
        else
        {
            currenttimerattack = defaulttimerattack;

        }

        if (currenttimerattack <= 0)
        {
            attack = false;
        }

        if (can <= 0)
        {
            MyAnimation.SetTrigger("Die");

            Invoke("Durdurma", 1.5f);

            can = 0;

            kalp.text = can.ToString();

            Invoke("OlumEkran", 2f);
        }
    }

    void Zipla()
    {

        if (Input.GetButtonDown("Jump") && havada == true)
        {
            if (yatay == 0)
            {
                MyAnimation.SetTrigger("Jump");
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, zýplamaSeviye), ForceMode2D.Impulse);
                StartCoroutine(Dus());
                havada = false;
            }
      
            if (yatay > 0)//karakterin yüzünün baktýðý yeri ayarlama
            {
                MyAnimation.SetTrigger("Jump");
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(2f, zýplamaSeviye), ForceMode2D.Impulse);
                StartCoroutine(Dus());
                havada = false;
            }
            else if (yatay < 0)
            {
                MyAnimation.SetTrigger("Jump");
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2f, zýplamaSeviye), ForceMode2D.Impulse);
                StartCoroutine(Dus());
                havada = false;
            }

        }

        IEnumerator Dus()
        {

            yield return new WaitForSeconds(0.5f);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -2f), ForceMode2D.Impulse);
        }
    }

    void Fire()
    {
        GameObject okumuz = Instantiate(Kasýk, transform.position + yon, Quaternion.identity);
        kasýkSes.Play();
        StartCoroutine(Wait(Kasýk));

        if (transform.localScale.x < 0)
        {
            okumuz.GetComponent<Rigidbody2D>().velocity = new Vector2(8f, 0f); //ok saða doðru

        }
        else
        {
            Vector3 okumuzscale = okumuz.transform.localScale;
            okumuz.transform.localScale = new Vector3(-okumuzscale.x, okumuzscale.y, okumuzscale.z);
            okumuz.GetComponent<Rigidbody2D>().velocity = new Vector2(-8f, 0f);// ok sola doðru

        }

        Destroy(okumuz, 1.5f);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Zemin"))
        {
            havada = true;
        }

        if (collision.gameObject.CompareTag("Dusman1"))
        {
            can--;

            kalp.text = can.ToString();
        }

    }

    IEnumerator Wait(GameObject okum)
    {
        yield return new WaitForSecondsRealtime(0.5f);

        GameObject okumuz = Instantiate(Kasýk, transform.position + yon, Quaternion.identity);

        kasýkSes.Play();

        if (transform.localScale.x < 0)
        {
            okumuz.GetComponent<Rigidbody2D>().velocity = new Vector2(8f, 0f); //ok saða doðru

        }
        else
        {
            Vector3 okumuzscale = okumuz.transform.localScale;
            okumuz.transform.localScale = new Vector3(-okumuzscale.x, okumuzscale.y, okumuzscale.z);
            okumuz.GetComponent<Rigidbody2D>().velocity = new Vector2(-8f, 0f);// ok sola doðru

        }

        Destroy(okumuz, 1.5f);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.gameObject.CompareTag("Balta"))
        {
            baltaSes.Play();

            can--;

            kalp.text = can.ToString();

            Destroy(collision.gameObject);

        }

        if (collision.gameObject.CompareTag("Kapý"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void Durdurma()
    {
        Time.timeScale = 0.2f;
    }

    public void OlumEkran()
    {
        SceneManager.LoadScene("Die");
    }
}
