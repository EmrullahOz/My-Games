using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public Transform levels;
    public Text currentLevelText;
    public int currentLevel;
    public GameObject _winPanel;
    public GameObject _failPanel;
    public GameObject _tutorial;
    void Start()
    {
        instance = this;
        //Level Kontrol
        for (int i = 0; i < levels.childCount; i++)
        {
            levels.GetChild(i).gameObject.SetActive(false);
        }
        levels.GetChild(PlayerPrefs.GetInt("Level")).gameObject.SetActive(true);
        currentLevel = (PlayerPrefs.GetInt("Level") + 1 + PlayerPrefs.GetInt("AddLevel"));
        currentLevelText.text = "Lvl " + currentLevel.ToString();
        if (PlayerPrefs.GetInt("Level") + PlayerPrefs.GetInt("AddLevel") == 0)
        {
            _tutorial.SetActive(true);
        }
    }

    void Update()
    {
       
    }
    // restart button
    public void CurrrentLevel()
    {
        SceneManager.LoadScene("GameScene");
    }

    // next button
    public void NextLevel()
    {
        if (PlayerPrefs.GetInt("Level") < levels.transform.childCount - 1)
        {
            PlayerPrefs.SetInt(("Level"), PlayerPrefs.GetInt("Level") + 1);
        }
        else
        {
            PlayerPrefs.SetInt(("Level"), 0);
            PlayerPrefs.SetInt("AddLevel", PlayerPrefs.GetInt("AddLevel") + (levels.transform.childCount));
        }

        SceneManager.LoadScene("GameScene");
    }
}
