using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform _convoy;
    public float _speed;
    [HideInInspector] public bool _isGame;
    [HideInInspector] public bool _isWin;
    [HideInInspector] public bool _right;
    [HideInInspector] public bool _left;
    [HideInInspector] public int _locationNum;
    private int _locationNumMax=1;
    private int _locationNumMin=-2;

    public List<Transform> _carFront;
    public List<Transform> _carSideRight;
    public List<Transform> _carSideLeft;
    [HideInInspector] public bool _isEnemyCollision;

    [HideInInspector] public Text _scoreText;
    [HideInInspector] public float _score=0;

    void Start()
    {
        instance = this;
        _locationNum = (int)(_convoy.position.x - 0.5f);
        _scoreText.text = "0";
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_isWin)
        {
            _isGame = true;
            LevelManager.instance._tutorial.SetActive(false);
        }

        Movement();
        CarControl();
    }

    // swipe movement system
    private void Movement()
    {
        if (_isGame)
        {
            _score += Time.deltaTime;
            _scoreText.text = (_score * (50+((PlayerPrefs.GetInt("Level") + PlayerPrefs.GetInt("AddLevel"))*3))).ToString("#");

            _convoy.Translate(transform.forward * _speed * Time.deltaTime);
        }

        if (_right)
        {
            _convoy.DOMoveX(_locationNum + 0.5f, 0.35f);
            _right = false;
        }
        if (_left)
        {
            _convoy.DOMoveX(_locationNum + 0.5f, 0.35f);
            _left = false;
        }
    }

    // car displacement
    private void CarControl()
    {
        if (_isEnemyCollision)
        {
            if (_carSideRight.Count == 0)
            {
                _locationNumMax++;
            }
            if (_carSideLeft.Count == 0)
            {
                _locationNumMin--;
            }
            if (_carFront.Count == 1)
            {
                _carFront[0].DOLocalMoveZ(2.25f, 0.5f);
            }
            if (_carSideRight.Count == 1)
            {
                _carSideRight[0].DOLocalMoveZ(0f, 0.5f);
            }
            if (_carSideLeft.Count == 1)
            {
                _carSideLeft[0].DOLocalMoveZ(0f, 0.5f);
            }
            _isEnemyCollision = false;
        }
    }
    #region // swipe control
    public void RightMOve()
    {
        if (_locationNum < _locationNumMax)
        {
            _right = true;
            _locationNum++;
        }   
    }
    public void LeftMove()
    {
        if (_locationNum > _locationNumMin)
        {
            _left = true;
            _locationNum--;
        }   
    }
    #endregion
}
