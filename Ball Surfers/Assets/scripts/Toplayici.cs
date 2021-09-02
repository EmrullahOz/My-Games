using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Toplayici : MonoBehaviour
{
    GameObject anaBall;
    public int yukseklik;

    public GameObject panel;

    void Start()
    {
        anaBall = GameObject.Find("AnaBall");
    }

    // Update is called once per frame
    void Update()
    {
        anaBall.transform.position = new Vector3(transform.position.x, yukseklik + 1, transform.position.z);
        this.transform.localPosition = new Vector3(0, -yukseklik, 0);
    }

    public void YukseklikAzalt()
    {
        yukseklik--;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Topla" && other.gameObject.GetComponent<ToplanabilirBall>().GetToplandiMi()==false)
        {
            yukseklik += 1;
            other.gameObject.GetComponent<ToplanabilirBall>().ToplandiYap();
            other.gameObject.GetComponent<ToplanabilirBall>().IndexAyarla(yukseklik);
            other.gameObject.transform.parent = anaBall.transform;

        }
        
        
        if (other.gameObject.CompareTag("Finish"))
        {
            
            panel.SetActive(true);
            Invoke("TimeTime", 0.5f);
        }
        
    }
    public void TimeTime()
    {
        Time.timeScale = 0;
    }

    public void Restart(int index)
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void Exit()
    {
        Application.Quit();
    }
}
