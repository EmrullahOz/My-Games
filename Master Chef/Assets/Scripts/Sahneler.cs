using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sahneler : MonoBehaviour
{
    public void SonrakiSahne(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void Tekrar()
    {


    }
    public void Cikis()
    {
        Application.Quit();
    }
}
