using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLine : MonoBehaviour
{
    public static StartLine �nstance;

    public GameObject panelDefeat;
    public float panelTime;
    public int stopEnemy;

    // Start is called before the first frame update
    void Start()
    {
        stopEnemy = 1;
        �nstance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //if (stopEnemy==true)
        //{
        //    EnemyMovement.�nstance.speedEnemy = -EnemyMovement.�nstance.speedEnemy;
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //panelDefeat.SetActive(true);
            //Time.timeScale = 0;
            stopEnemy=0;
            Invoke("DefeatPanel", panelTime);
        }
    }
    public void DefeatPanel()
    {
        panelDefeat.SetActive(true);
        Time.timeScale = 0;
    }
}
