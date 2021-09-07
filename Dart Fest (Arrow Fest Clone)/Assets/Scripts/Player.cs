using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject StartUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HitOff()
    {

        StartCoroutine(hitSetStart());

    }

    IEnumerator hitSetStart()
    {
        yield return new WaitForSeconds(1.5f);

        StartUI.SetActive(true);
    }
}
