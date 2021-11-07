using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject _player;

    private float _distanceEnemy;
    private float _nearestSpawn;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _distanceEnemy = Vector3.Distance(transform.position, _player.transform.position);
        _nearestSpawn = GameManager.instance._nearestEnemySpawn;

        if (_distanceEnemy >= _nearestSpawn)
        {
            transform.GetComponent<MeshRenderer>().enabled = true;
            transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
        }
        if (_distanceEnemy < _nearestSpawn)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _player.transform.position, Time.deltaTime/10);

    }
}
