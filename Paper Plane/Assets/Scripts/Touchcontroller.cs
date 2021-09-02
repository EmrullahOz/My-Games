using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touchcontroller : MonoBehaviour
{
    public static Touchcontroller instance;

    private Touch touch;
    private float speedModifier;

    public bool hitTrue;
    private Animator baseballAnim;

    public float speed;
    public GameObject target;
    public GameObject target2;
    public GameObject startBaseBall;
    public GameObject startUI;

    private bool startOn = false;

    public ParticleSystem par;
    public ParticleSystem par1;

    //public GameObject[] xler;
    //public Transform xlerd;
    // Start is called before the first frame update
    void Awake()
    {
        
        speedModifier = 0.00000001f;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (target.transform.position.x >= 4f)
        {
            target.transform.position = new Vector3(3.9f, target.transform.position.y, target.transform.position.z);
            target2.transform.position = new Vector3(3.9f, target2.transform.position.y, target2.transform.position.z);
        }

        if (target.transform.position.x <= -4f)
        {
            target.transform.position = new Vector3(-3.9f, target.transform.position.y, target.transform.position.z);
            target2.transform.position = new Vector3(-3.9f, target2.transform.position.y, target2.transform.position.z);
        }

        if (target.transform.position.x <= 4f && target.transform.position.x >= -4f)
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Moved)
                {
                    transform.position = new Vector3(
                        transform.position.x + touch.deltaPosition.x * Time.deltaTime + speedModifier,
                        transform.position.y,
                        transform.position.z);
                }
            }
        }
       

        transform.Translate(Vector3.forward* speed * Time.deltaTime);

        //if (StartBaseBall.instance.startOn == true)
        //{
        //    target2.GetComponent<MeshRenderer>().enabled = true;
        //    startBaseBall.gameObject.SetActive(false);
        //    startUI.gameObject.SetActive(true);


        //    if (Input.GetMouseButton(0))
        //    {
        //        speed = 10;
        //        target2.transform.GetComponent<Touchcontroller>().speed = 10;
        //        startUI.gameObject.SetActive(false);
        //        startOn = true;
        //    }
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Artý"))
        {
            oynanýs.instance.angle = 0.1f;
            oynanýs.instance.radius = 0.25f;
            oynanýs.instance.ballCount += other.GetComponent<Wall>().number;
            par.Play();
        }

        if (other.CompareTag("Bolme"))
        {
            oynanýs.instance.angle = 0.1f;
            oynanýs.instance.radius = 0.25f;
            oynanýs.instance.ballCount /= other.GetComponent<WallBolme>().number;
            par1.Play();
        }

        if (other.CompareTag("Eksi"))
        {
            oynanýs.instance.angle = 0.1f;
            oynanýs.instance.radius = 0.25f;
            oynanýs.instance.ballCount -= other.GetComponent<WallEksi>().number;
            par1.Play();
        }

        if (other.CompareTag("Carpma"))
        {
            oynanýs.instance.angle = 0.1f;
            oynanýs.instance.radius = 0.25f;
            oynanýs.instance.ballCount *= other.GetComponent<WallCarpma>().number;
            par.Play();
        }

        if (other.CompareTag("Finish"))
        {
            CameraController.instance.enabled = false;

            if (oynanýs.instance.kum1.Count >= 0)
            {
               
                StartCoroutine(SetBallskum1());
            }
            //if (oynanýs.instance.ballCount>=1)
            //{
            //    //transform.position = Vector3.Lerp(transform.position, xlerd.position, Time.deltaTime);
            //    target2.GetComponent<Touchcontroller>().transform.position = Vector3.Lerp(transform.position, xlerd.position, Time.deltaTime);
            //}
           

        }

    
    }

    IEnumerator SetBallskum1()
    {
       

        for (int i = 0; i < oynanýs.instance.ballCount; i++)
        {
            yield return new WaitForSeconds(.00001f);
            print("a");

            oynanýs.instance.kum1[i].GetComponent<Rigidbody>().useGravity = true;
        }
       
    }

    //IEnumerator SetBallskum2()
    //{
    //    for (int i = 0; i <= oynanýs.instance.limit; i++)
    //    {
    //        yield return new WaitForSeconds(.00001f);
    //        oynanýs.instance.kum2[i].GetComponent<Rigidbody>().useGravity = true;
    //    }
    //}

    //IEnumerator SetBallskum3()
    //{


    //    for (int i = 0; i <= oynanýs.instance.limit; i++)
    //    {
    //        yield return new WaitForSeconds(.00001f);
    //        oynanýs.instance.kum3[i].GetComponent<Rigidbody>().useGravity = true;
    //    }

    //}
}
