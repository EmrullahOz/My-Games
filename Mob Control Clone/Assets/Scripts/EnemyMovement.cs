using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speedEnemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.forward * -speedEnemy * Time.deltaTime*StartLine.Ýnstance.stopEnemy);

        if (transform.position.x <= -5f)
        {
            transform.position = new Vector3(-4.99f, transform.position.y, transform.position.z);

        }
        else if (transform.position.x >= 5f)
        {
            transform.position = new Vector3(4.99f, transform.position.y, transform.position.z);
        }
        if (EnemyTowerScript.Ýnstance.towerPoint <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
