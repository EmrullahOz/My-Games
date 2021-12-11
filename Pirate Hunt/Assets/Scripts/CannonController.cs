using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CannonController : MonoBehaviour
{

    public float _rotationSpeed = 1;
    public float _blastPower = 5;
    public float _mousePosX, _mousePosZ;
    public GameObject _cannonBall;
    public Transform _shotPoint;
    public GameObject _explosion;
    public int _cannonBallCount;
    public int _cannonBallCountMax=50;

    private void Start()
    {
        _cannonBallCountMax = GameManager.instance._ballCount;
    }

    private void Update()
    {
        // Fire 
        if (Input.GetMouseButtonUp(0) && !IsMouseOverUI())
        {
            if (_cannonBallCount<_cannonBallCountMax)
            {
                GameObject _createdCannonball = Instantiate(_cannonBall, _shotPoint.position, _shotPoint.rotation);
                _createdCannonball.GetComponent<Rigidbody>().velocity = _shotPoint.transform.up * _blastPower;
                Destroy(_createdCannonball, 15f);

                // Added explosion for added effect
                Destroy(Instantiate(_explosion, _shotPoint.position, _shotPoint.rotation), 2);

                // Shake the screen for added effect
                Screenshake.ShakeAmount = 3;
                _cannonBallCount++;
                GameManager.instance._ballCount--;
                GameManager.instance._balltext.text = GameManager.instance._ballCount.ToString();
            }
            
        }

        #region Connon Control
        if (Input.GetMouseButtonDown(0) && !IsMouseOverUI())
        {
            _mousePosX = Input.mousePosition.y;
            _mousePosZ = Input.mousePosition.x;

        }

        if (Input.GetMouseButton(0))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles +new Vector3((_mousePosX-Input.mousePosition.y)*0.25f * _rotationSpeed, (_mousePosZ-Input.mousePosition.x) * 0.30f * -_rotationSpeed,0));
        }

        if (transform.rotation.eulerAngles.x<359f && transform.rotation.eulerAngles.x>=180)
        {
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }
        if (transform.rotation.eulerAngles.x<180f && transform.rotation.eulerAngles.x>=52)
        {
            transform.rotation = Quaternion.Euler(51, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }
        if (transform.rotation.eulerAngles.y <= 310f && transform.rotation.eulerAngles.y >= 180)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 311, transform.rotation.eulerAngles.z);
        }
        if (transform.rotation.eulerAngles.y <180f && transform.rotation.eulerAngles.y >= 50)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 49, transform.rotation.eulerAngles.z);
        }
        #endregion

    }

    // Cursor UI or Game
    bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
