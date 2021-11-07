using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaberControl : MonoBehaviour
{
    [SerializeField]
    [Range(1, 50)]
    float _rotationSpeed;
    private float _saberSpeed;
    private float _saberScaleY;

    private GameObject _turnPoint;
    private GameObject _target;
    private Vector3 _targetPoint;
    private float _distance;

    float _rot = 0;
    private bool _isThrowed;
    private bool _turnBack;
    private bool _targetControl;
    private bool _attack;
    
    void Start()
    {
        _turnPoint = GameObject.Find("Arm");
        _target = GameObject.Find("Target");
        transform.position = new Vector3(_turnPoint.transform.position.x, _turnPoint.transform.position.y, _turnPoint.transform.position.z);
        _attack = true;
        _rotationSpeed = GameManager.instance._saberRotationSpeed;
        _saberSpeed = GameManager.instance._saberMovementSpeed;
        _saberScaleY = GameManager.instance._saberScaleLenght;
        transform.localScale = new Vector3(0.2f, _saberScaleY, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
        _distance = Vector3.Distance(transform.position, _turnPoint.transform.position);
        if (_distance >= GameManager.instance._saberDistance)
        {
            _isThrowed = false;
            _turnBack = true;

        }
        if (_isThrowed == false && _turnBack == false)
        {
            transform.position = _turnPoint.transform.position;
            //transform.position = new Vector3(turnPoint.transform.position.x , turnPoint.transform.position.y , turnPoint.transform.position.z);
        }
        if (_distance <= 0.5f)
        {
            _turnBack = false;
            _targetControl = true;
            transform.rotation = Quaternion.Euler(90,_turnPoint.transform.parent.eulerAngles.y,0);
        }
        if (_distance >= 0.5f)
        {
            _targetControl = false;
        }
        if (_targetControl)
        {
            _targetPoint = _target.transform.position;
        }
        if (_turnBack)
        {
            TurnBack();
            //_targetPoint = _target.transform.position;
        }
        if (Input.GetMouseButtonUp(0) && _attack==true)
        {
            _isThrowed = true;
            StartCoroutine(SetAttack());
        }
        if (_isThrowed )
        {
            Rotation();
            Throw();    
        }
        
    }
    public void TurnBack()
    {
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(turnPoint.transform.position.x , turnPoint.transform.position.y , turnPoint.transform.position.z), Time.deltaTime*20);
        transform.position = Vector3.MoveTowards(transform.position, _turnPoint.transform.position, Time.deltaTime*20);
        Rotation();
    }
    public void Rotation()
    {
        _rot += _rotationSpeed * Time.deltaTime*20;
        transform.rotation = Quaternion.Euler(90, _rot, 0);
    }
    public void Throw()
    {       
        //Vector3 vek = new Vector3(turnPoint.position.x, turnPoint.position.y , turnPoint.position.z + 10);
        transform.position = Vector3.MoveTowards(transform.position, _targetPoint, Time.deltaTime * _saberSpeed);
    }
    IEnumerator SetAttack()
    {
        _attack = false;
        yield return new WaitForSeconds(1f);
        _attack = true;

    }
}
