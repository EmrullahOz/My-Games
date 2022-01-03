using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    private GameObject _bullets;
    private int _bulletCount;
    private float _timer = 0.4f;
    void Start()
    {
        _bullets = GameObject.Find("Bullets");
    }

    void Update()
    {
        if (GameManager.instance._ingame)
        {
            if (Input.GetMouseButton(0))
            {
                _timer += Time.deltaTime;
                if (_timer >= 0.4f)
                {
                    _bullets.transform.GetChild(_bulletCount).gameObject.SetActive(true);
                    _bulletCount++;
                    _timer = 0;
                }
            }
            if (_bulletCount >= _bullets.transform.childCount)
            {
                _bulletCount = 0;
            }
        }
        else
        {
            for (int i = 0; i < _bullets.transform.childCount; i++)
            {
                _bullets.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
