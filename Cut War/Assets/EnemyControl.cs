using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public GameObject _enemy;
    private GameObject _enemies;
    private Vector3 _creationPos;
    private float _creationPointX;
    private float _creationPointZ;
    private int _childCount;
    private int _maxEnemy;

    // Start is called before the first frame update
    void Start()
    {      
        _enemies = GameObject.Find("Enemies");
        _maxEnemy = GameManager.instance._maxEnemyCount;

        InvokeRepeating("Creation", 2f, 1.5f);
    }

    // Update is called once per frame                  
    void Update()
    {
        _childCount = transform.childCount;

    }
    public void Creation()
    {
        if (_childCount <= _maxEnemy)
        { 
            _creationPointX = Random.Range(-38, 38);
            _creationPointZ = Random.Range(-38, 38);
            _creationPos = new Vector3(_creationPointX, 1.5f, _creationPointZ);
            var _enemyClone = Instantiate(_enemy, _creationPos, Quaternion.identity);
            _enemyClone.transform.parent = _enemies.transform;
        }
        else if (_childCount > _maxEnemy)
        {
            
        }
    }
    
}
