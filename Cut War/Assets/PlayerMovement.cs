using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Transform _player;
    [HideInInspector]
    public Vector3 _move;

    public float _moveSpeed;
    private bool _moving;
    public RectTransform _pad;
    public GameObject _joys;

    private bool _moveOff;

    void Start()
    {
        _player = GameObject.Find("Player").transform;
        _pad = transform.GetChild(0).GetComponent<RectTransform>();
        _joys = transform.GetChild(0).GetChild(0).gameObject;
        _moveSpeed = GameManager.instance._playerMovementSpeed;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _joys.transform.position = eventData.position;
        _joys.transform.localPosition = Vector2.ClampMagnitude(eventData.position - (Vector2)_pad.position, _pad.rect.width * 0.4f);

        _move = new Vector3(_joys.transform.localPosition.x, 0, _joys.transform.localPosition.y).normalized;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _pad.gameObject.SetActive(false);
        _joys.transform.localPosition = Vector3.zero;
        _move = Vector3.zero;
        _moving = false;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _moving = true;
        _pad.transform.position = eventData.position;

    }


    private void Update()
    {
        
        if (_moving)
        {
            _pad.gameObject.SetActive(true);

            if (_moveOff == false)
            {
                _player.Translate(_move * _moveSpeed * Time.deltaTime, Space.World);
                print("ab");
            }

            if (_move != Vector3.zero)
            {
                _player.rotation = Quaternion.Slerp(_player.rotation, Quaternion.LookRotation(_move), 5 * Time.deltaTime);
            }
        }
    }





    //private float _movementSpeed = 5;
    //private float _rotationSpeed = 500;

    //private Touch _touch;

    //private Vector3 _touchDown;
    //private Vector3 _touchUp;

    //private bool _dragStarted;

    //void Start()
    //{

    //}

    //void Update()
    //{
    //    _movementSpeed = GameManager.instance._playerMovementSpeed;

    //    if (Input.touchCount > 0)
    //    {
    //        _touch = Input.GetTouch(0);
    //        if (_touch.phase == TouchPhase.Began)
    //        {
    //            _dragStarted = true;
    //            _touchUp = _touch.position;
    //            _touchDown = _touch.position;
    //        }
    //    }
    //    if (_dragStarted)
    //    {
    //        if (_touch.phase == TouchPhase.Moved)
    //        {
    //            _touchDown = _touch.position;
    //        }

    //        if (_touch.phase == TouchPhase.Ended)
    //        {
    //            _touchDown = _touch.position;
    //            _dragStarted = false;
    //        }
    //        gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, CalculateRotation(), _rotationSpeed * Time.deltaTime);
    //        gameObject.transform.Translate(Vector3.forward * Time.deltaTime * _movementSpeed);
    //    }
    //}


    //Quaternion CalculateRotation()
    //{
    //    Quaternion temp = Quaternion.LookRotation(CalculateDirection(), Vector3.up);
    //    return temp;
    //}
    //Vector3 CalculateDirection()
    //{
    //    Vector3 temp = (_touchDown - _touchUp).normalized;
    //    temp.z = temp.y;
    //    temp.y = 0;
    //    return temp;
    //}
}
