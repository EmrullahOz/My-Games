using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBall : MonoBehaviour
{
    private Animator myAnim;

    public GameObject target2;
    public GameObject target1;
    public GameObject finishUI;
    public GameObject StartUI;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        //finishUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HitOn()
    {

        target2.transform.GetComponent<Touchcontroller>().speed = 240;
        target1.transform.GetComponent<Touchcontroller>().speed = 240;

    }

    public void HitOff()
    {

        StartCoroutine(hitSet());

    }

    IEnumerator hitSet()
    {
        yield return new WaitForSeconds(2f);

        finishUI.SetActive(true);
    }

    IEnumerator hitSetStart()
    {
        yield return new WaitForSeconds(1.5f);

        StartUI.SetActive(true);
    }


}
