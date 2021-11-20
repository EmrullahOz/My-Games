using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int _unitCubes;

    // Start is called before the first frame update
    void Awake()
    {
        instance=this;

        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 0)
        {
            _unitCubes = PlayerPrefs.GetInt("UnitCubes");
            _unitCubes = 0;
            PlayerPrefs.SetInt("UnitCubes", _unitCubes);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SelectUnitCubes(int _unit)
    {
        _unitCubes= PlayerPrefs.GetInt("UnitCubes");
        _unitCubes = _unit;
        PlayerPrefs.SetInt("UnitCubes", _unitCubes);
    }
}
