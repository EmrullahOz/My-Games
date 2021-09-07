using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyTowerScript : MonoBehaviour
{
    public static EnemyTowerScript Ýnstance;

    public GameObject enemy;
    float number;
    public float downLimit;
    public float upLimit;

    public TMP_Text towerText;
    public int towerPoint;

    public ParticleSystem partic;

    public GameObject panelVictory;
    public float panelTime;

    public float spawn;

    MeshRenderer meshRenderer;
    BoxCollider boxCollider;

    private void Awake()
    {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        boxCollider = gameObject.GetComponent<BoxCollider>();
    }
    void Start()
    {
        Ýnstance = this;
        towerText.text = towerPoint.ToString();
        InvokeRepeating("EnemyCreating", 2f, spawn);
    }

    // Update is called once per frame
    void Update()
    {
        //InvokeRepeating("EnemyCreating", 2f, 1f);
        if (towerPoint<=0)
        {

            meshRenderer.enabled = false;
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
            StartCoroutine(CoroutineActivePanel());
            //panelVictory.SetActive(true);
            //Time.timeScale = 0;
            //Destroy(this.gameObject, 0.2f);
        }
    }

    public void EnemyCreating()
    {
        number = Random.Range(downLimit,upLimit);
        Instantiate(enemy, new Vector3(number, transform.position.y, transform.position.z), Quaternion.identity);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Military"))
        {
            partic.Play();
            Invoke("ParticleClose", 0.3f);
        }
    }
    public void ParticleClose()
    {
        partic.Stop();
    }
    IEnumerator CoroutineActivePanel()
    {
        
        yield return new WaitForSecondsRealtime(panelTime);
        panelVictory.SetActive(true);
        Time.timeScale = 0;
    }
}
