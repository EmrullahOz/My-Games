using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimousineController : MonoBehaviour
{
    private int _healht=2;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            _healht--;
            if (_healht<=0)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
                StartCoroutine(Fail());
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            StartCoroutine(Win());       
        }
    }

    IEnumerator Win()
    {
        GameManager.instance._isGame = false;
        GameManager.instance._isWin = true;
        EnemyCar.instance._speed = 0;
        GameManager.instance._scoreText.text = ((GameManager.instance._score * 50)+(GameManager.instance._convoy.childCount*250)).ToString("#");
        yield return new WaitForSeconds(0.5f);
        LevelManager.instance._winPanel.SetActive(true);
    }
    IEnumerator Fail()
    {
        GameManager.instance._isGame = false;
        GameManager.instance._isWin = true;
        yield return new WaitForSeconds(0.5f);
        LevelManager.instance._failPanel.SetActive(true);
    }
}
