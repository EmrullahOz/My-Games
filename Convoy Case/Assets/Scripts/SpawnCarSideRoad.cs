using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCarSideRoad : MonoBehaviour
{
    private float _timer;
    private float _rdTimer = 4.5f;
    private float[] _posX = { -0.375f, -0.125f, 0.125f, 0.375f}; 

    void Start()
    {
        
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
            if (_timer >= _rdTimer)
            {
                int rdX = Random.Range(-3, 4);
                int rdZ = Random.Range(0, 5);
                int rdCar = Random.Range(0, SpawnCar.instance._cars.Count);
                if (rdX < 0)
                {
                    GameObject car= Instantiate(SpawnCar.instance._cars[rdCar], new Vector3(-8, 0, transform.position.z), Quaternion.Euler(0, 90, 0)).gameObject;
                    car.transform.parent = transform;
                    car.transform.GetComponent<EnemyCar>()._isForward = true;
                    car.transform.GetComponent<EnemyCar>()._isRight = true;
                    car.transform.localPosition = new Vector3(_posX[rdZ], car.transform.localPosition.y, car.transform.localPosition.z);
                }
                else if (rdX > 0)
                {
                    GameObject car = Instantiate(SpawnCar.instance._cars[rdCar], new Vector3(8, 0, transform.position.z), Quaternion.Euler(0, 270, 0)).gameObject;
                    car.transform.parent = transform;
                    car.transform.GetComponent<EnemyCar>()._isForward = true;
                    car.transform.localPosition = new Vector3(_posX[rdZ], car.transform.localPosition.y, car.transform.localPosition.z);
                }
                _rdTimer = Random.Range(3.25f, 4.5f);
                _timer = 0;
            }
        }
    }
}
