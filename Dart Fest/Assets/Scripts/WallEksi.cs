using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WallEksi : MonoBehaviour
{
    public static WallEksi instance;

    public int number;

    private TextMeshPro sayý;

    void Start()
    {
        instance = this;
        sayý = transform.GetChild(0).GetComponent<TextMeshPro>();
        sayý.text = "-" + number;
    }
}
