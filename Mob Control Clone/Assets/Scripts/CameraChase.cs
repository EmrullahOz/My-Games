using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraChase : MonoBehaviour
{
    public GameObject target;
    Vector3 distance;

    private void Awake()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void Start()
    {
        
        int activeScene = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("levelSaved", activeScene);
        print(activeScene);
        distance = new Vector3(0, transform.position.y, transform.position.z) - new Vector3(0, target.transform.position.y, target.transform.position.z);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(transform.position.x,target.transform.position.y+distance.y,target.transform.position.z+distance.z),  Time.deltaTime);
    }

    public void Restart()
    {
        int levelScene = PlayerPrefs.GetInt("levelSaved");
        SceneManager.LoadScene(levelScene);
    }
    public void Next()
    {
        int levelScene = PlayerPrefs.GetInt("levelSaved");
        SceneManager.LoadScene(levelScene+1);
    }
    public void Reset()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }

}
