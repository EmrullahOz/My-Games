using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MultiWall : MonoBehaviour
{
    public static MultiWall Ýnstance;

    public TMP_Text multiText;
    public int multi;
    // Start is called before the first frame update
    void Start()
    {
        Ýnstance = this;

        multiText.text = multi.ToString()+ "×";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
