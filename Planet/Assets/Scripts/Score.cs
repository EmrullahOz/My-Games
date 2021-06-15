using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text Skor;
    public float Zaman;

    public string Tamsayý;
    // Start is called before the first frame update
    void Start()
    {
        //Skor.text = Zaman.ToString();
        // Zaman = decimal.Round(Zaman);
        // Zaman = miktar.ToString("0.##");
        //PlayerPrefs.SetFloat("Puan", Zaman);
    }

    // Update is called once per frame
    void Update()
    {
        Zaman += Time.deltaTime * 5;

        Tamsayý = Zaman.ToString("0.");

        PlayerPrefs.SetFloat("Puan", Zaman);

        Skor.text = Tamsayý.ToString();
    }
}
