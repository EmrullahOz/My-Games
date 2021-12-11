using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    public GameObject _ship;
    public GameObject _pirate;

    [Header("Ship and pirate Count")]
    private int _shipCount=0;
    public int _shipCountMax;
    private int _pirateCount=0;
    public int _pirateCountMax;

    void Start()
    {
        _shipCountMax = GameManager.instance._shipCount;
        _pirateCountMax = GameManager.instance._pirateCount;

        InvokeRepeating("SpawnShip", 0.5f, 7.5f);
        InvokeRepeating("SpawnPirate", 5f, 7.5f);
    }

    public void SpawnShip()
    {
        if (_shipCount<_shipCountMax)
        {
            int a = Random.Range(1, 3);
            float b = Random.Range(91, 155.1f);
            if (a == 1)
            {
                var _spawnShip = Instantiate(_ship, new Vector3(190, 8.5f, b), Quaternion.Euler(0, 270, 0));
            }
            if (a == 2)
            {
                var _spawnShip = Instantiate(_ship, new Vector3(-190, 8.5f, b), Quaternion.Euler(0, 90, 0));
            }
        }
        _shipCount++;       
    }
    
    
    public void SpawnPirate()
    {
        if (_pirateCount<_pirateCountMax)
        {
            float a = Random.Range(-35, 35.1f);
            float b = Random.Range(75, 110.1f);
            var _spawnShip = Instantiate(_pirate, new Vector3(a, 0, b), Quaternion.Euler(0, 180, 0));
        }
        _pirateCount++;
    }
}
