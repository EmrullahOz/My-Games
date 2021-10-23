using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game Element")]
    public float speed;
    public float speedGarbage;
    
    void Start()
    {
        Instance = this;
    }

    void Update()
    {
        
    }

    // Function that runs the try again button
    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
