using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{
    private float _speedShip=6;

    private bool _sinkShipPos;
    private bool _sinkShipNeg;

    public GameObject _explosionShip;

    void Update()
    {
        if (!_sinkShipPos && !_sinkShipNeg)
            transform.Translate(Vector3.forward * _speedShip * Time.deltaTime);
         
        if (_sinkShipPos)
        {
            transform.RotateAround(transform.position, new Vector3(30, 0, 0), 16 * Time.deltaTime);
            transform.Translate(Vector3.down * _speedShip/ 1.6f * Time.deltaTime);
            Destroy(gameObject, 4.6f);
        }
        if (_sinkShipNeg)
        {
            transform.RotateAround(transform.position, new Vector3(-30, 0, 0), 16 * Time.deltaTime);
            transform.Translate(Vector3.down * _speedShip/1.6f * Time.deltaTime);
            Destroy(gameObject, 4.6f);
        }
        if (transform.position.x > 190)
            transform.eulerAngles = new Vector3(0, 270, 0);
        
        if (transform.position.x < -190)
            transform.eulerAngles = new Vector3(0, 90, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CannonBall"))
        {
            Destroy(Instantiate(_explosionShip, other.gameObject.transform.position, other.gameObject.transform.rotation), 3);
            Destroy(other.gameObject);
            if (transform.rotation.eulerAngles.y>=0)
            {
                _sinkShipPos = true;
            }
            if (transform.rotation.eulerAngles.y<0)
            {
                _sinkShipNeg = true;
            }
            GameManager.instance._destroyEnemyCount++;
            GameManager.instance._shipCount--;
            GameManager.instance._shiptext.text = GameManager.instance._shipCount.ToString();
        }
    }
}
