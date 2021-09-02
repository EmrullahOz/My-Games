using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallTextControl : MonoBehaviour
{
    private TextMeshPro ballCount;
    void Start()
    {
        ballCount = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        ballCount.text = oynanýs.instance.ballCount.ToString();
    }
}
