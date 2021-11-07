using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float _playerMovementSpeed;

    public float _saberDistance;
    public float _saberRotationSpeed;
    public float _saberMovementSpeed;
    public float _saberScaleLenght;

    public int _maxEnemyCount;
    public float _nearestEnemySpawn;

    private GameObject _plane;
    public Vector3 _planeScale;


    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        _plane = GameObject.Find("Plane");
        _plane.transform.localScale = _planeScale;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
