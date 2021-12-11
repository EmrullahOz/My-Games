using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("Game Tools")]
    public int _shipCount;
    public int _pirateCount;
    public int _ballCount;
    public int _destroyEnemyCount;

    [Header("Text and Panels")]
    public GameObject _sucPanel;
    public GameObject _failPanel;
    public TextMeshProUGUI _shiptext;
    public TextMeshProUGUI _piratetext;
    public TextMeshProUGUI _balltext;

    private bool _panelControl;

    void Awake()
    {
        instance = this;

        // random ship and pirate count
        _shipCount = Random.Range(5, 10);
        _pirateCount = Random.Range(3, 7);
        _ballCount=2*(_shipCount+_pirateCount);

        // Texts
        _shiptext.text = _shipCount.ToString();
        _piratetext.text = _pirateCount.ToString();
        _balltext.text = _ballCount.ToString();

    }

    private void Update()
    {
        if ((_shipCount + _pirateCount)==0)
        {
            Invoke("SucPanel",0.8f);
            _panelControl = true;
        }
        if (_ballCount==0 && !_panelControl)
        {
            if ((_shipCount + _pirateCount) == 1)
            {
                Invoke("FailPanel", 5f);
            }
            if ((_shipCount + _pirateCount) > 1)
            {
                Invoke("FailPanel", 0.8f);
            }
            
        }
    }

    public void SucPanel()
    {
        _sucPanel.gameObject.SetActive(true);
    }
    public void FailPanel()
    {
        _failPanel.gameObject.SetActive(true);
    }
}
