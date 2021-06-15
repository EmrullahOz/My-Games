using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sonuc : MonoBehaviour
{
    private Score TextiAlma;
    public Text sonucText;
    public GameObject Sonucobje;

    //private string Skore;

    public float zamanplayer;
    public String zamanlayýcý;


    // Start is called before the first frame update
    void Start()
    {
        //Skore = TextiAlma.Zaman.ToString();
      



        zamanplayer = PlayerPrefs.GetFloat("Puan");

        zamanlayýcý = zamanplayer.ToString("0.#");

        sonucText.text = zamanlayýcý.ToString();

    }

    // Update is called once per frame
    void Update()
    {
       
        
        

        
    }
}
