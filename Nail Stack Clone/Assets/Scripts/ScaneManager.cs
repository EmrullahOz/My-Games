using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScaneManager : MonoBehaviour
{
    public GameObject _startButton;
    
    void Start()
    {
        Time.timeScale = 0;
    }

    public void StartButton()
    {
        Time.timeScale = 1;
        _startButton.SetActive(false);
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }

}
