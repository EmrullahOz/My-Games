using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex+1);
    }

    public void NextButton()
    {
        if (GameManager.instance._sceneGameCount> UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (GameManager.instance._sceneGameCount== UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
        
    }
    public void RestartButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex );
    }

}
