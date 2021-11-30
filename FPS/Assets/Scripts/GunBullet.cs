using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBullet : MonoBehaviour
{
    public Vector3 target;
    public float Scale;

    [Header("Particle System")]
    public ParticleSystem _explosionTimeBomb;
    public ParticleSystem _explosionTimeBombScale;
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, 4f);

        //if time bomb is checked
        if (GameManager.instance._timeBombBullet)      
            StartCoroutine(SetTimeBomb());

        //if Change Scale is checked
        if (GameManager.instance._changeScaleBullet)
            transform.localScale = new Vector3(Scale, Scale, Scale);

        //if Change Color is checked
        if (GameManager.instance._changeColorBullet)
            GetComponent<MeshRenderer>().material.color = Color.red;
    }


    // Time bomb explodes in one second
    IEnumerator SetTimeBomb()
    {
        yield return new WaitForSeconds(1f);
        if (GameManager.instance._changeScaleBullet == false) Instantiate(_explosionTimeBomb, transform.position, Quaternion.identity);
        if (GameManager.instance._changeScaleBullet == true) Instantiate(_explosionTimeBombScale, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    //function where the target disappears
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TargetPaper"))
        {
            Debug.Log("Hedef isabet ald�/Hedef vuruldu");
            Destroy(other.gameObject,0.1f);
            Debug.Log("Hedef yok edildi/Hedef kullan�lamaz halde");
        }
    }
}
