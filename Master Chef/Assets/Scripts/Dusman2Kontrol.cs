using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dusman2Kontrol : MonoBehaviour
{
    public GameObject target;
    public GameObject target1;
    public float Can;
    public GameObject Kasýk;
    public CapsuleCollider2D dusmanZýrhý;
    private bool hareketizin;
    public float hýz;
    public Animator dusmanAnimator;
    Vector3 yon;
    bool attack;
    [SerializeField] float currenttimerattack;
    [SerializeField] float defaulttimerattack;
    bool atýsIzýn;
    public AudioSource baltaSes;
    // Start is called before the first frame update
    void Start()
    {
        atýsIzýn = false;
        attack = false;
        hareketizin = false;
        dusmanZýrhý = GetComponent<CapsuleCollider2D>();

        yon = new Vector3(-0.5f, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (hareketizin == true)
        {
            if (target.transform.position.x > transform.position.x)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, hýz * Time.deltaTime);
                transform.localScale = new Vector3(-1, 1, 1);
            }
            if (target.transform.position.x < transform.position.x)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, hýz * Time.deltaTime);
                transform.localScale = new Vector3(1, 1, 1);
            }

        }

        if (target1.transform.position.x <= target.transform.position.x)
        {
            hareketizin = true;
            dusmanAnimator.SetTrigger("walk");
            attack = false;
            atýsIzýn = true;
        }

        if (Can <= 0)
        {
            dusmanAnimator.SetTrigger("Die");
            hýz = 0;
            Destroy(gameObject, 2f);

        }

        if(attack == false && atýsIzýn == true)
        {
            dusmanAnimator.SetTrigger("Attack");      
            attack = true;
        }

        if (attack == true)
        {
            currenttimerattack -= Time.deltaTime;
        }

        if (currenttimerattack <= 0)
        {
            currenttimerattack = defaulttimerattack;
            StartCoroutine(Wait(Kasýk));
            attack = false;
        }
     
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Kasýk"))
        {
            Debug.Log("Vuruldu");
            Can--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dusmanAnimator.SetTrigger("Attack");

        }
    }

    void Fire()
    {
        StartCoroutine(Wait(Kasýk));

       
    }

    IEnumerator Wait(GameObject okum)
    {
        yield return new WaitForSecondsRealtime(0.5f);

        GameObject okumuz = Instantiate(Kasýk, transform.position + yon, Quaternion.identity);

        baltaSes.Play();

        if (transform.localScale.x < 0)
        {
            okumuz.GetComponent<Rigidbody2D>().velocity = new Vector2(5f, 0f); //ok saða doðru

        }
        else
        {
            Vector3 okumuzscale = okumuz.transform.localScale;
            okumuz.transform.localScale = new Vector3(-okumuzscale.x, okumuzscale.y, okumuzscale.z);
            okumuz.GetComponent<Rigidbody2D>().velocity = new Vector2(-5f, 0f);// ok sola doðru

        }

        Destroy(okumuz, 3f);

    }
}
