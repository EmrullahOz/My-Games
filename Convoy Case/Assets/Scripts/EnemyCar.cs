using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCar : MonoBehaviour
{
    public static EnemyCar instance;
    public float _speed;
    private float _timerDie;
    public bool _isForward;
    public bool _isRight;

    void Start()
    {
        instance = this;
        if (transform.position.x > 0)
        {
            _speed = Random.Range(3f, 4f);
        }
        else if (transform.position.x < 0)
        {
            _speed = Random.Range(1.5f, 2.25f);
        }      
    }

    void Update()
    {
        Move();
        _timerDie += Time.deltaTime;
        if (_timerDie > 25f)
        {
            Destroy(gameObject);
        }
    }
    void Move()
    {
        if (!_isForward)
        {
            if (transform.position.x > 0)
            {
                transform.Translate(transform.forward * _speed * Time.deltaTime);
            }
            else if (transform.position.x < 0)
            {
                transform.Translate(-transform.forward * _speed * Time.deltaTime);
            }
        }
        if (_isForward)
        {
            if (!_isRight)
            {
                transform.Translate(transform.right * _speed * Time.deltaTime);
            }
            else if (_isRight)
            {
                transform.Translate(-transform.right * _speed * Time.deltaTime);
            }
        }  
    }
}
