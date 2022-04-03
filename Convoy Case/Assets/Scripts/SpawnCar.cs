using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCar : MonoBehaviour
{
    public static SpawnCar instance;
    public List<Transform> _cars;
    private float _timer;
    private float _rdTimer=1f;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        if (GameManager.instance._isGame && !GameManager.instance._isWin)
        {
            _timer += Time.deltaTime;
            if (_timer>=_rdTimer)
            {
                int rdX = Random.Range(-3, 3);
                int rdZ = Random.Range(14, 22);
                int rdCar = Random.Range(0, _cars.Count);
                if (rdX<0)
                {
                    Instantiate(_cars[rdCar], new Vector3(rdX + 0.5f, 0, GameManager.instance._convoy.position.z + rdZ), Quaternion.Euler(0, 180, 0));
                }
                else if (rdX>=0)
                {
                    Instantiate(_cars[rdCar], new Vector3(rdX + 0.5f, 0, GameManager.instance._convoy.position.z + rdZ), Quaternion.identity);
                }
                _rdTimer = Random.Range(2.25f, 3.5f);
                _timer = 0;
            }
        }
    }
}
