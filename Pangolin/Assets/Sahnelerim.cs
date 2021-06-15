using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sahnelerim : MonoBehaviour
{
    public GameObject OyunPaneli;
    public GameObject PuanPaneli;
    public GameObject TekrarPaneli;

   
    public void SonrakiSahne()
    {
        SceneManager.LoadScene("Game");
    }
    public void Tekrar()
    {
       

    }
    public void Cikis()
    {
        Application.Quit(); 
    }
}
