using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{


    void Start()
    {

    }
    private void Update()
    {
        GameManager.instance._unitCubes = PlayerPrefs.GetInt("UnitCubes");
    }

    public void StartButton(int _scene)
    {
        if (GameManager.instance._unitCubes!=0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(_scene);
        }
    }
    public void RestartButton(int _scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_scene);
    }
}
