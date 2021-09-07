using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryUltra : MonoBehaviour
{

    [SerializeField]
    private float speedMilitary;

    public GameObject militaryClone;
    public GameObject enemyTower;
    public float sure;
    bool attack;

    public int life;
    int a;

    float rand;

    // Start is called before the first frame update
    void Start()
    {
        a = 3;  
        enemyTower = GameObject.Find("EnemyTower");
        attack = false;
        StartCoroutine(CoroutineTest2());
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.forward * speedMilitary * Time.deltaTime);

        if (transform.position.x <= -5f)
        {
            transform.position = new Vector3(-4.99f, transform.position.y, transform.position.z);

        }
        else if (transform.position.x >= 5f)
        {
            transform.position = new Vector3(4.99f, transform.position.y, transform.position.z);
        }
        if (attack == true && enemyTower != null)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(enemyTower.transform.position.x, enemyTower.transform.position.y+0.7f, enemyTower.transform.position.z - 2.0f), 1.0f * Time.deltaTime);
        }
        if (enemyTower == null)
        {
            this.transform.Translate(Vector3.forward * speedMilitary * Time.deltaTime);
        }
        if (life==2)
        {
            gameObject.transform.localScale = new Vector3(0.80f, 1.25f, 0.80f);
            a = 2;
        }
        if (life==1)
        {
            gameObject.transform.localScale = new Vector3(0.60f, 1.0f, 0.60f);
            a = 1;
        }
        if (life<=0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Multiwall") && sure == 0)
        {
            for (int i = 0; i < other.gameObject.GetComponent<MultiWall>().multi - 1; i++)
            {
                rand = Random.Range(-0.80f, 0.81f);
                print(other.gameObject.GetComponent<MultiWall>().multi);
                Instantiate(militaryClone, new Vector3(transform.position.x+rand, transform.position.y, transform.position.z), Quaternion.identity);
                StartCoroutine(CoroutineTest2());
            }
        }
        if (other.gameObject.CompareTag("TowerCircle"))
        {
            attack = true;
        }
        if (other.gameObject.CompareTag("Tower"))
        {
            EnemyTowerScript.Ýnstance.towerPoint -= a;
            EnemyTowerScript.Ýnstance.towerText.text = EnemyTowerScript.Ýnstance.towerPoint.ToString();
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            life--;
        }
    }
    IEnumerator CoroutineTest2()
    {
        sure = 1;
        yield return new WaitForSecondsRealtime(1.0f);
        sure = 0;
    }
}
