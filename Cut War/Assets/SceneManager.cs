using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    private GameObject _startButton;

    void Start()
    {
        _startButton = GameObject.Find("StartButton");
        Time.timeScale = 0;
    }

    public void StartButton()
    {
        Time.timeScale = 1;
        _startButton.SetActive(false);
    }
    public void RestartButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
