using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dusman1Kontrol : MonoBehaviour
{
    public GameObject target;
    public GameObject target1;
    public float Can;

    public CapsuleCollider2D dusmanZýrhý;
    private bool hareketizin;
    public float hýz;
    public Animator dusmanAnimator;

    public AudioSource attackSes;

    // Start is called before the first frame update
    void Start()
    {
        hareketizin = false;
        dusmanZýrhý = GetComponent<CapsuleCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (hareketizin == true)
        {
            if (target.transform.position.x > transform.position.x)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, hýz * Time.deltaTime);
                transform.localScale = new Vector3(-1,1,1);
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
        }

        if (Can <= 0)
        {
            dusmanAnimator.SetTrigger("Die");
            hýz = 0;
            Destroy(gameObject, 1.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.gameObject.CompareTag("Kasýk"))
        {
           
            Can--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dusmanAnimator.SetTrigger("Attack");

            attackSes.Play();

        }
    }

}
