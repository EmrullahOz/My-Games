using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float rightLeftSpeed;
    [SerializeField]
    private float speed;

    public GameObject military;
    public GameObject militaryUltra;
    GameObject mil;

    int numb;
    float dist;
    public Image bar;
    float barnumb;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        numb = 0;
        mil = military;
    }

    // Update is called once per frame
    void Update()
    {
        float yatayEksen = Input.GetAxis("Horizontal") * rightLeftSpeed * Time.deltaTime;
        this.transform.Translate(yatayEksen, 0, speed * Time.deltaTime);

        if (transform.position.x <= -5f)
        {
            transform.position = new Vector3(-4.99f, transform.position.y, transform.position.z);

        }
        else if (transform.position.x >= 5f)
        {
            transform.position = new Vector3(4.99f, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown("space") )
        {
            InvokeRepeating("Creating", 0.5f,0.7f);
            
        }

        if (Input.GetKeyUp("space"))
        {
            CancelInvoke("Creating");
        }
        if (numb>=10)
        {
            //barnumb = 0;
            StartCoroutine(CoroutineMil());
        }
        if (numb==0)
        {
            mil = military;
        }

    }

    public void Creating()
    {
        GameObject clone= Instantiate(mil,new Vector3(transform.position.x, transform.position.y+dist,transform.position.z ),Quaternion.identity);
        numb++;
        barnumb += 0.1f;
        bar.fillAmount = barnumb;
    }
    IEnumerator CoroutineMil()
    {
        mil = militaryUltra;
        dist = 0.75f;
        yield return new WaitForSecondsRealtime(1.2f);
        barnumb = 0;
        numb = 0;
        dist = 0;
    }
}
