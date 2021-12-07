using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterControl : MonoBehaviour
{
    public static CharacterControl instance;

    private float mouseFirstPosX;
    public float speedForward = 5;
    private float _startSpeed = 3;
    private float _accountSpeed = 10;
    private float _rateSpeed = 1f;
    private int speedRightLeft = 20;
    private float bounders=3;

    private Vector3 _ballVector;
    private float _timer=0;
    public float _rotateSpeedBall=250;

    public int _account;
    public int _accountTotal=1;
    private float _timerAccount;
    private float _delay=1.6f;

    private bool _active;

    private TMP_Text _textAccount;
    private TMP_Text _textEnd;

    private float _ballScaleUp=0.002f;
    private bool _end;
    public int _endWallCount=0;

    void Start()
    {
        instance = this;

        _textAccount = gameObject.transform.GetChild(2).GetChild(0).transform.GetComponent<TextMeshPro>();
        _textEnd = gameObject.transform.GetChild(3).GetChild(0).transform.GetComponent<TextMeshPro>();

    }
    void Update()
    {
        _timerAccount -= Time.deltaTime;

        if (!_end)
        {
            transform.Translate(Vector3.forward * speedForward * Time.deltaTime);
            if (Input.GetMouseButtonDown(0))
            {
                mouseFirstPosX = Input.mousePosition.x;
            }
            else if (Input.GetMouseButton(0))
            {
                if (Input.mousePosition.x != mouseFirstPosX)
                {
                    transform.position = transform.position + transform.right * (Input.mousePosition.x - mouseFirstPosX) / speedRightLeft * Time.deltaTime;
                }
            }
        }
        if (_end)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 3, transform.position.z), speedForward * Time.deltaTime);
            if (transform.position.x==0)
            {
                transform.position = Vector3.MoveTowards(transform.position, GameManager.instance._endWall.transform.GetChild(_endWallCount).transform.position, speedForward * 3 * Time.deltaTime);
            }
            if (transform.position.z== GameManager.instance._endWall.transform.GetChild(_endWallCount).transform.position.z)
            {
                Invoke("SucPanel", 1f);
            }
        }

        Bounders();

        RandomRotation();

        CharacterActive();

        _textAccount.text = _accountTotal.ToString();

        if (speedForward<1)
        {
            speedForward = 1;
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
        if (_timer<=0)
        {
            _ballVector = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)); 
            _timer = 2;
        }      
    }

    // character activation system
    public void CharacterActive()
    {
        if (_active && gameObject.transform.GetChild(1).childCount>_accountTotal)
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
                gameObject.transform.GetChild(1).GetChild(gameObject.transform.GetChild(1).childCount-1-i).gameObject.SetActive(false);
            }
        }
        if (_accountTotal <= 0)
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

    // Finish system
    IEnumerator Finished()
    {
        if (gameObject.transform.GetChild(1).transform.childCount<_accountTotal)
        {
            for (int i = 0; i < gameObject.transform.GetChild(1).transform.childCount; i++)
            {
                yield return new WaitForSeconds(0.02f);
                gameObject.transform.GetChild(1).GetChild(i).transform.position = gameObject.transform.GetChild(0).transform.position;
                gameObject.transform.GetChild(0).transform.localScale += new Vector3(_ballScaleUp, _ballScaleUp, _ballScaleUp);
                if (i == gameObject.transform.GetChild(1).transform.childCount - 1)
                {
                    _end = true;
                }
            }
        }
        if (gameObject.transform.GetChild(1).transform.childCount>=_accountTotal)
        {
            for (int i = 0; i < _accountTotal; i++)
            {
                yield return new WaitForSeconds(0.04f);
                gameObject.transform.GetChild(1).GetChild(i).transform.position = gameObject.transform.GetChild(0).transform.position;
                gameObject.transform.GetChild(0).transform.localScale += new Vector3(_ballScaleUp, _ballScaleUp, _ballScaleUp);
                if (i == _accountTotal - 1)
                {
                    _end = true;
                }
            }
        }
        if ((_accountTotal / 10)<8)
        {
            _endWallCount = _accountTotal / 10;
        }
        if ((_accountTotal / 10)>=8)
        {
            _endWallCount = 8;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall1") && _timerAccount<=0 )
        {
            
            _account= other.gameObject.transform.parent.GetComponent<WallControl>()._count1;
            if (other.gameObject.transform.parent.GetComponent<WallControl>()._processAccount1==1)
            {
                _accountTotal += _account;
                _active = true;
                ChangeSpeedRotate();
            }
            if (other.gameObject.transform.parent.GetComponent<WallControl>()._processAccount1==2)
            {
                _accountTotal *= _account;
                _active = true;
                ChangeSpeedRotate();
            }
            if (other.gameObject.transform.parent.GetComponent<WallControl>()._processAccount1==3)
            {
                _accountTotal -= _account;
                _active = false;
                ChangeSpeedRotate();
            }
            if (other.gameObject.transform.parent.GetComponent<WallControl>()._processAccount1==4)
            {
                _accountTotal /= _account;
                _active = false;
                ChangeSpeedRotate();
            }
        }
        if (other.gameObject.CompareTag("Wall2") && _timerAccount <= 0)
        {
            
            _account= other.gameObject.transform.parent.GetComponent<WallControl>()._count2;
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
            _accountTotal -= 2;
            _active = false;
        }
        if (other.gameObject.CompareTag("SpeedUp"))
        {
            speedForward += 5;
        }
        if (other.gameObject.CompareTag("SpeedDown"))
        {
            speedForward -= 3;
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
            StartCoroutine(Finished());
            GameManager.instance._endWall.transform.position = new Vector3(GameManager.instance._finish.transform.position.x, GameManager.instance._finish.transform.position.y , GameManager.instance._finish.transform.position.z + 15);
            GameManager.instance._sliderPl.gameObject.SetActive(false);
            GameManager.instance._sliderOp.gameObject.SetActive(false);
            OpponentControl.instance.speedForward = 0;
        }
        if (other.gameObject.CompareTag("EndWall") )
        {
            other.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            other.gameObject.transform.GetChild(0).GetComponent<ParticleSystem>().Play();   
        }
    }

    //Success panel
    public void SucPanel()
    {
        GameManager.instance._sucPanel.gameObject.SetActive(true);
        gameObject.transform.GetChild(3).gameObject.SetActive(true);
        _textEnd.text = "×" + (_endWallCount + 2).ToString();
        //Time.timeScale = 0f;
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
