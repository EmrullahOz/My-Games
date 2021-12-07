using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentControl : MonoBehaviour
{
    public static OpponentControl instance;

    public float speedForward = 5;
    private float _startSpeed = 3;
    private float _accountSpeed = 10;
    private float _rateSpeed = 1f;
    private int speedRightLeft = 2;
    private float bounders = 3;

    private Vector3 _ballVector;
    private float _timer = 0;
    private float _rotateSpeedBall = 250;

    public int _account;
    public int _accountTotal = 1;
    private float _timerAccount;
    private float _delay = 2f;

    private bool _active;

    private float _timerOpponent=0;
    public float _randomX=0;

    void Start()
    {
        instance = this;

    }
    void Update()
    {
        _timerAccount -= Time.deltaTime;

        transform.Translate(Vector3.forward * speedForward * Time.deltaTime);

        RandomMovement();
        
        Bounders();

        RandomRotation();

        CharacterActive();


        if (speedForward < 1)
        {
            speedForward = 1;
        }
    }

    public void RandomMovement()
    {
        _timerOpponent -= Time.deltaTime;
        if (_timerOpponent <= 0)
        {
            _randomX = Random.Range(-bounders, bounders);
            _timerOpponent = 1f;
        }
        if (_timerOpponent > 0)
        {
            transform.position = transform.position + transform.right * _randomX * speedRightLeft * Time.deltaTime;
        }
    }

    // limitation of the character's movements
    public void Bounders()
    {
        Vector3 boundry = transform.position;
        boundry.x = Mathf.Clamp(boundry.x, -bounders, bounders);
        transform.position = boundry;
    }

    //random spin of the ball
    public void RandomRotation()
    {
        _timer -= Time.deltaTime;
        transform.GetChild(0).RotateAround(transform.GetChild(0).position, _ballVector, _rotateSpeedBall * Time.deltaTime);
        if (_timer <= 0)
        {
            _ballVector = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
            _timer = 2;
        }
    }

    // character activation system
    public void CharacterActive()
    {
        if (_active && gameObject.transform.GetChild(1).childCount > _accountTotal)
        {
            for (int i = 0; i < _accountTotal; i++)
            {
                gameObject.transform.GetChild(1).GetChild(i).gameObject.SetActive(true);
            }
        }
        if (!_active && gameObject.transform.GetChild(1).childCount >= _accountTotal)
        {
            for (int i = 0; i < gameObject.transform.GetChild(1).childCount - _accountTotal; i++)
            {
                gameObject.transform.GetChild(1).GetChild(gameObject.transform.GetChild(1).childCount - 1 - i).gameObject.SetActive(false);
            }
        }
        if (_accountTotal < 1)
        {
            _accountTotal = 1;
            gameObject.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
        }
    }

    //change in ball rotation speed
    public void ChangeSpeedRotate()
    {
        _timerAccount = _delay;
        speedForward = _startSpeed + ((_accountTotal / _accountSpeed) * _rateSpeed);
        _rotateSpeedBall = 250 + ((_accountTotal / _accountSpeed) * 25);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall1") && _timerAccount <= 0)
        {

            _account = other.gameObject.transform.parent.GetComponent<WallControl>()._count1;
            if (other.gameObject.transform.parent.GetComponent<WallControl>()._processAccount1 == 1)
            {
                _accountTotal += _account;
                _active = true;
                ChangeSpeedRotate();
            }
            if (other.gameObject.transform.parent.GetComponent<WallControl>()._processAccount1 == 2)
            {
                _accountTotal *= _account;
                _active = true;
                ChangeSpeedRotate();
            }
            if (other.gameObject.transform.parent.GetComponent<WallControl>()._processAccount1 == 3)
            {
                _accountTotal -= _account;
                _active = false;
                ChangeSpeedRotate();
            }
            if (other.gameObject.transform.parent.GetComponent<WallControl>()._processAccount1 == 4)
            {
                _accountTotal /= _account;
                _active = false;
                ChangeSpeedRotate();
            }
        }
        if (other.gameObject.CompareTag("Wall2") && _timerAccount <= 0)
        {

            _account = other.gameObject.transform.parent.GetComponent<WallControl>()._count2;
            if (other.gameObject.transform.parent.GetComponent<WallControl>()._processAccount2 == 1)
            {
                _accountTotal += _account;
                _active = true;
                ChangeSpeedRotate();
            }
            if (other.gameObject.transform.parent.GetComponent<WallControl>()._processAccount2 == 2)
            {
                _accountTotal *= _account;
                _active = true;
                ChangeSpeedRotate();
            }
            if (other.gameObject.transform.parent.GetComponent<WallControl>()._processAccount2 == 3)
            {
                _accountTotal -= _account;
                _active = false;
                ChangeSpeedRotate();
            }
            if (other.gameObject.transform.parent.GetComponent<WallControl>()._processAccount2 == 4)
            {
                _accountTotal /= _account;
                _active = false;
                ChangeSpeedRotate();
            }
        }
        if (other.gameObject.CompareTag("Collect"))
        {
            Destroy(other.gameObject);
            _accountTotal++;
            _active = true;
        }
        if (other.gameObject.CompareTag("Obstacle"))
        {
            //other.gameObject.GetComponent<BoxCollider>().enabled = false;
            _accountTotal -= 2;
            _active = false;
        }
        if (other.gameObject.CompareTag("SpeedUp"))
        {
            //other.gameObject.GetComponent<BoxCollider>().enabled = false;
            speedForward += 5;
        }
        if (other.gameObject.CompareTag("SpeedDown"))
        {
            //other.gameObject.GetComponent<BoxCollider>().enabled = false;
            speedForward -= 3;
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            GameManager.instance._sliderPl.gameObject.SetActive(false);
            GameManager.instance._sliderOp.gameObject.SetActive(false);
            Time.timeScale = 0.25f;
            Invoke("FailPanel", 0.25f);
        }
    }

    //Fail panel
    public void FailPanel()
    {
        GameManager.instance._failPanel.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    private void OnTriggerStay(Collider other)
    {
        if (_accountTotal < 1)
        {
            _accountTotal = 1;
            gameObject.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
        }
    }
}
