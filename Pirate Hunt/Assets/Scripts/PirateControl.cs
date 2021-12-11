using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PirateControl : MonoBehaviour
{
    private float _speedPirate = 2.5f;

    public GameObject _explosionPirate;

    void Update()
    {
        transform.Translate(Vector3.forward * _speedPirate * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CannonBall"))
        {
            Destroy(Instantiate(_explosionPirate, other.gameObject.transform.position, other.gameObject.transform.rotation), 1);
            Destroy(gameObject);
            Destroy(other.gameObject, 0.1f);
            GameManager.instance._destroyEnemyCount++;
            GameManager.instance._pirateCount--;
            GameManager.instance._piratetext.text = GameManager.instance._pirateCount.ToString();
        }
        if (other.gameObject.CompareTag("Border"))
        {
            
            Invoke("FailPanel", 0.8f);
        }
    }
    public void FailPanel()
    {
        GameManager.instance._failPanel.gameObject.SetActive(true);
    }
}
