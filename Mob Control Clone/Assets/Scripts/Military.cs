using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Military : MonoBehaviour
{

    [SerializeField]
    private float speedMilitary;

    public GameObject militaryClone;
    public GameObject enemyTower;
    public float sure;
    bool attack;

    // Start is called before the first frame update
    void Start()
    {
        
        //enemyTower = GameObject.Find("EnemyTower");
        attack = false;
        StartCoroutine(CoroutineTest2());
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.forward*speedMilitary*Time.deltaTime);

        if (transform.position.x <= -5f)
        {
            transform.position = new Vector3(-4.99f, transform.position.y, transform.position.z);

        }
        else if (transform.position.x >= 5f)
        {
            transform.position = new Vector3(4.99f, transform.position.y, transform.position.z);
        }
        if (attack==true&&enemyTower!=null)
        {
            this.transform.position = Vector3.Lerp(this.transform.position,new Vector3(enemyTower.transform.position.x,enemyTower.transform.position.y,enemyTower.transform.position.z-2.0f), 1.0f* Time.deltaTime);
        }
        if (enemyTower==null)
        {
            this.transform.Translate(Vector3.forward * speedMilitary * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Multiwall") && sure==0)
        {
            for (int i = 0; i < other.gameObject.GetComponent<MultiWall>().multi-1; i++)
            {
   
                    print(other.gameObject.GetComponent<MultiWall>().multi);
                    Instantiate(militaryClone, new Vector3(transform.position.x, transform.position.y, transform.position.z ), Quaternion.identity);
                StartCoroutine(CoroutineTest2());
            }
        }
        if (other.gameObject.CompareTag("TowerCircle"))
        {
            print(other.gameObject.transform.parent);
            enemyTower = GameObject.Find(other.gameObject.transform.parent.name);
            attack = true;        
        }
        if (other.gameObject.CompareTag("Tower"))
        {
            
            EnemyTowerScript.Ýnstance.towerPoint -= 1;
            EnemyTowerScript.Ýnstance.towerText.text = EnemyTowerScript.Ýnstance.towerPoint.ToString();
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
    IEnumerator CoroutineTest2()
    {
        sure =1;
        yield return new WaitForSecondsRealtime(1.0f);
        sure = 0;
    }


}
