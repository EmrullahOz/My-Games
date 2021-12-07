using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int _sceneGameCount;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _opponent;
    public GameObject _finish;
    public Slider _sliderPl;
    public Slider _sliderOp;
    [SerializeField] private float _distPl;
    [SerializeField] private float _distOp;

    public GameObject _endWall;

    private bool _pauseGame;
    public GameObject _sucPanel;
    public GameObject _failPanel;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;

        Time.timeScale = 1;

        _player = GameObject.Find("Character");
        _opponent = GameObject.Find("Opponent");
        _finish = GameObject.Find("Finish");

        _sliderPl.maxValue = _finish.transform.position.z - _player.transform.position.z;
        _sliderOp.maxValue = _finish.transform.position.z - _opponent.transform.position.z;

        _endWall= GameObject.Find("EndWall");
        _endWall.transform.position = new Vector3(_finish.transform.position.x, _finish.transform.position.y-100, _finish.transform.position.z + 15);
    }

    // Update is called once per frame
    void Update()
    {
        // player & opponent slider bar movement
        _distPl = _finish.transform.position.z - _player.transform.position.z;
        _distOp = _finish.transform.position.z - _opponent.transform.position.z;
        _sliderPl.value = _sliderPl.maxValue - _distPl;
        _sliderOp.value = _sliderOp.maxValue - _distOp;
    }

    // pause button system
    public void Pause()
    {
        if (_pauseGame==false)
        {
            Time.timeScale = 0f;
            _pauseGame = true;
        }
        else
        {
            Time.timeScale = 1f;
            _pauseGame = false;
        }
    }
   
}
