using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Sahnelerim : MonoBehaviour
{
    public GameObject PanelPause;
    public void Sahneindex (int sahne)
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1 );
        //UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        Time.timeScale = 1;
        //UnityEngine.SceneManagement.SceneManager.LoadScene("Bolum1");
        UnityEngine.SceneManagement.SceneManager.LoadScene(sahne);
    }

    public void Cýkýs()
    {
        Application.Quit();
        
    }

    public void Pause()
    {
        Time.timeScale = 0;
        PanelPause.SetActive(true);
    }

    public void DevamEt()
    {
        Time.timeScale = 1;
        PanelPause.SetActive(false);
    }
   
}
