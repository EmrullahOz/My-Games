using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    private Transform _player;
    public float _speed;

    void Start()
    {
        _player = GameObject.FindObjectOfType<PlayerControl>().transform;
    }

    void Update()
    {
        transform.Translate(_player.forward * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            GameManager.instance._partic[PlayerControl.instance._count].Play();
            gameObject.SetActive(false);
            Destroy(other.gameObject);
            other.gameObject.transform.parent.transform.position = new Vector3(other.gameObject.transform.parent.transform.position.x, other.gameObject.transform.parent.transform.position.y - 0.7f, other.gameObject.transform.parent.transform.position.z);
        }
        if (other.gameObject.CompareTag("Obstacle"))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        transform.position = new Vector3(_player.position.x, _player.position.y - 0.25f, _player.position.z);
    }
}
