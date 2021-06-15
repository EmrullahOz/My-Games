using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SphereController : MonoBehaviour
{
    public Transform endMarker;
    public float Speed;
    private float startTime;
    private float journeyLength;
    public int a;
    public GameObject kup;
    public GameObject Begin;
    public List<GameObject> Cubes = new List<GameObject>();
    void Start()
    {
        Time.timeScale = 0;
        DOTween.Init();
        startTime = Time.time;
        journeyLength = Vector3.Distance(transform.position, endMarker.position);
        a = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.DOLocalRotate(new Vector3(0, 360, 0), 2f, RotateMode.WorldAxisAdd);
        float distCovered = (Time.time - startTime) * Speed;
        float fraction = distCovered / journeyLength;
        transform.position = Vector3.Lerp(transform.position, endMarker.position, fraction * Time.deltaTime);

        if (Input.GetKeyDown("a") && transform.position.x > -3.5f)
        {
            Vector3 left = new Vector3(-1f, 0, 0);
            transform.position = Vector3.Lerp(transform.position + left, endMarker.position, fraction * Time.deltaTime);
        }
        if (Input.GetKeyDown("d") && transform.position.x < 4.3f)
        {
            Vector3 right = new Vector3(1f, 0, 0);
            transform.position = Vector3.Lerp(transform.position + right, endMarker.position, fraction * Time.deltaTime);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Yesil"))
        {
            Destroy(collision.gameObject);
            GameObject yenikup = Instantiate(kup, gameObject.transform.position+new Vector3(0,-1-a,0), Quaternion.identity,gameObject.transform);
           
            Cubes.Add(yenikup);
            transform.Translate(transform.position.x, 1, 0);
            a++;
        }
        if (collision.gameObject.CompareTag("Engel"))
        {
            Destroy(collision.gameObject);
            Destroy(Cubes[Cubes.Count - 1]);
            transform.Translate(transform.position.x, 0, 0);
            a--;
        }
    }

    public void Play()
    {
        Time.timeScale = 1;
        Begin.SetActive(false);
    }
    
}