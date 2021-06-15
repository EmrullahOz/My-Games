using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneKontrol : MonoBehaviour
{
    public GameObject PausePanel;
    // Start is called before the first frame update
    public void Basla()
    {
        SceneManager.LoadScene(1);
    }

    public void Anamenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }

    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void Cýkýs()
    {
        Application.Quit();
    }

    public void Pause()
    {
        Time.timeScale = 0;
        PausePanel.gameObject.SetActive(true);

    }

    public void Devam()
    {
        Time.timeScale = 1;
        PausePanel.gameObject.SetActive(false);

    }

}
