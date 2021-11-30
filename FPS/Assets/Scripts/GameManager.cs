using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int _shotGunBullets;
    public Animator _aimAnimator;

    [Header("Guns")]
    public GameObject _gun;
    public GameObject _shotGun;
    public TextMeshProUGUI _gunText;
    [HideInInspector] public int _gunBulletCount;
    public TextMeshProUGUI _shotGunText;
    [HideInInspector]public int _shotGunBulletCount;

    [HideInInspector]
    public bool _timeBombBullet;
    public bool _changeScaleBullet;
    public bool _changeColorBullet;

    public Image[] _ButtonsTick;
    public Material[] _shutgunMaterials;

    [Header("Counts")]
    private int CountChangegun = 0;
    private int CountTimeBomb = 0;
    private int CountChangeScale = 0;
    private int CountChangeColor = 0;

    [Header("Levels")]
    private GameObject _levels;
    private GameObject _levelNumber;
    public int _targetCount;

    [Header("Canvas")]
    [SerializeField] private GameObject _startCanvas;
    [SerializeField] private GameObject _finishCanvas;
    [SerializeField] private GameObject _gameCanvas;
    [SerializeField] private TextMeshProUGUI _levelText;

    [Header("GunsReload")]
    private bool _gunReload;
    private bool _shotGunReload = true;

    void Awake()
    {
        instance = this;

        Time.timeScale = 0;
        _startCanvas = GameObject.Find("StartCanvas");
        _finishCanvas = GameObject.Find("FinishCanvas");
        _gameCanvas = GameObject.Find("Canvas");
        _startCanvas.SetActive(true);
        _finishCanvas.SetActive(false);
        _gameCanvas.SetActive(false);
        _shotGun.SetActive(true);
        _gunText.gameObject.SetActive(false);
        _levels = GameObject.Find("Levels");
        _levelNumber = _levels.transform.GetChild(0).gameObject;
        _targetCount =_levelNumber.transform.childCount;
        _gunBulletCount = 60;
        _shotGunBulletCount = 10;
    }

    void Update()
    {
        _gunText.text = _gunBulletCount.ToString();
        _shotGunText.text = _shotGunBulletCount.ToString();

        // Change Guns Color
        if (!_timeBombBullet && !_changeScaleBullet && !_changeColorBullet)
            _shotGun.transform.GetChild(1).GetComponent<MeshRenderer>().material = _shutgunMaterials[0];

        if (_timeBombBullet)
            _shotGun.transform.GetChild(1).GetComponent<MeshRenderer>().material = _shutgunMaterials[2];

        if (_changeColorBullet)
            _shotGun.transform.GetChild(1).GetComponent<MeshRenderer>().material = _shutgunMaterials[1];

        // marking of buttons
        if (Input.GetKeyDown(KeyCode.Q)) SetButtonTimeBomb();
        if (Input.GetKeyDown(KeyCode.E)) SetButtonChangeScale();
        if (Input.GetKeyDown(KeyCode.T)) SetButtonChangeColor();
        if (Input.GetKeyDown(KeyCode.F)) ChangeGun();
        if (Input.GetKeyDown(KeyCode.R)) Reload();

        _targetCount = _levelNumber.transform.childCount;
        _levelText.text = "Level " + (_levelNumber.transform.GetSiblingIndex() + 1).ToString();

        StartCoroutine("LevelSystem");
    }

    #region functions of keys

    //the function with which the weapon change is made
    public void ChangeGun()
    {
        CountChangegun++;

        if (CountChangegun % 1 == 0)
        {
            Debug.Log("Silah deðiþtirildi/Gun aktif");
            _gun.SetActive(true);
            _shotGun.SetActive(false);
            _shotGunText.gameObject.SetActive(false);
            _gunText.gameObject.SetActive(true);
            _gunReload = true;
            _shotGunReload = false;
        }

        if (CountChangegun % 2 == 0)
        {
            Debug.Log("Silah deðiþtirildi/ShotGun aktif");
            _gun.SetActive(false);
            _shotGun.SetActive(true);
            _shotGunText.gameObject.SetActive(true);
            _gunText.gameObject.SetActive(false);
            _gunReload = false;
            _shotGunReload = true;
        }
    }

    //function for reloading
    public void Reload()
    {
        if (_shotGunReload)
        {
            _shotGunBulletCount = 10;
            Debug.Log("Þarjör dolduruldu");
        }
        if (_gunReload)
        {
            _gunBulletCount = 60;
            Debug.Log("Þarjör dolduruldu");
        }
    }

    //the function to add the bomb feature to the bullet
    public void SetButtonTimeBomb()
    {
        CountTimeBomb++;

        if (CountTimeBomb % 1 == 0)
        {
            _timeBombBullet = true;
            _ButtonsTick[0].gameObject.SetActive(true);
        }

        if (CountTimeBomb % 2 == 0)
        {
            _timeBombBullet = false;
            _ButtonsTick[0].gameObject.SetActive(false);
        }
    }

    //function to change the size of the projectile
    public void SetButtonChangeScale()
    {
        CountChangeScale++;

        if (CountChangeScale % 1 == 0)
        {
            _changeScaleBullet = true;
            _ButtonsTick[1].gameObject.SetActive(true);
        }

        if (CountChangeScale % 2 == 0)
        {
            _changeScaleBullet = false;
            _ButtonsTick[1].gameObject.SetActive(false);
        }
    }

    //function to change the color of the bullet
    public void SetButtonChangeColor()
    {
        CountChangeColor++;

        if (CountChangeColor % 1 == 0)
        {
            _changeColorBullet = true;
            _ButtonsTick[2].gameObject.SetActive(true);
        }

        if (CountChangeColor % 2 == 0)
        {
            _changeColorBullet = false;
            _ButtonsTick[2].gameObject.SetActive(false);
        }
    }
    #endregion

    //The function where the level pass system is made
    IEnumerator LevelSystem()
    {
        for (int i = _levelNumber.transform.GetSiblingIndex(); i < _levels.transform.childCount; i++)
        {
            if (i< _levels.transform.childCount-1)
            {
                if (_levels.transform.GetChild(i).childCount == 0)
                {
                    _levels.transform.GetChild(i).gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    Gun.instance.ParticalDeath();
                    _levels.transform.GetChild(i + 1).gameObject.SetActive(true);
                    _levelNumber = _levels.transform.GetChild(i + 1).gameObject;
                }
            }if (i== _levels.transform.childCount-1)
            {
                if (_levels.transform.GetChild(i).childCount == 0)
                {
                    _levels.transform.GetChild(i).gameObject.SetActive(false);
                    yield return new WaitForSeconds(1f);
                    Gun.instance.ParticalDeath();
                    _levels.transform.GetChild(0).gameObject.SetActive(true);
                    _levelNumber = _levels.transform.GetChild(0).gameObject;
                    _gameCanvas.SetActive(false);
                    _finishCanvas.SetActive(true);
                    Time.timeScale = 0;
                    PlayerController.instance.lockCursor = false;
                }
            }
        }
    }

    public void StartButton()
    {
        Time.timeScale = 1;
        _startCanvas.SetActive(false);
        _gameCanvas.SetActive(true);
        PlayerController.instance.lockCursor = true;
    }
    public void RestartButton(int index)
    {
        SceneManager.LoadScene(index);
    }
}
