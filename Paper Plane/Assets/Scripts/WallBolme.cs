using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WallBolme : MonoBehaviour
{
    public static WallBolme instance;

    public int number;

    private TextMeshPro sayý;

    void Start()
    {
        instance = this;
        sayý = transform.GetChild(0).GetComponent<TextMeshPro>();
        sayý.text = "÷" + number;
    }
}
