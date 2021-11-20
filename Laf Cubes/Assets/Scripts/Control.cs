using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public static Control instance;

    private GameObject _cube;
    [HideInInspector]
    public GameObject _cubes;
    private GameObject _button;
    private GameObject _buttonCubes;

    [HideInInspector]
    public int _cubesCount;
    private bool _completion;

    private GameObject _twoButton;
    private GameObject _threeButton;
    private GameObject _fourButton;
    private GameObject _buttonPoints;
    private float _buttonPoint;

    // Start is called before the first frame update
    void Awake()
    {
        //_cubesCount = PlayerPrefs.GetInt("UnitCubes");
        instance = this;

        _cubesCount = PlayerPrefs.GetInt("UnitCubes");

        _cube= Resources.Load<GameObject>("Cube");
        _cubes = GameObject.Find("Cubes");
        _button= Resources.Load<GameObject>("ButtonCube");
        _buttonCubes = GameObject.Find("ButtonCubes");
        _twoButton = GameObject.Find("Block2");
        _threeButton = GameObject.Find("Block3");
        _fourButton = GameObject.Find("Block4");
        _buttonPoints = GameObject.Find("ButtonPoints");

        Creating();

    }
    private void Start()
    {
        ButtonPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100.0f) && hit.transform.CompareTag("Block"))
            {
                //Destroy(hit.transform.gameObject);

            }
        }
        
    }

    public void Creating()
    {
 
        for (int i = 0; i < _cubesCount; i++)
        {  
            
            for (int j = 0; j < _cubesCount; j++)
            {
                GameObject _cub= Instantiate(_cube,new Vector3(j,1,i ), Quaternion.identity);
                _cub.transform.parent = _cubes.transform;
                if (_cubes.transform.childCount == (_cubesCount * _cubesCount))
                {
                    _completion= true;
                }
            }
        }
        if (_completion)
        {
            for (int i = 0; i < _cubesCount; i++)
            {
                GameObject _but = Instantiate(_button, new Vector3(_cubes.transform.GetChild(i).position.x, 1, _cubes.transform.GetChild(i).position.z - 1f), Quaternion.Euler(0,270,0));
                _but.transform.parent = _buttonCubes.transform.GetChild(0).transform;
            }
            for (int i = 0; i < _cubesCount; i++)
            {
                GameObject _but = Instantiate(_button, new Vector3(_cubes.transform.GetChild(((i + 1) * _cubesCount) - 1).position.x + 1f, 1, _cubes.transform.GetChild(((i + 1) * _cubesCount) - 1).position.z), Quaternion.Euler(0, 180, 0));
                _but.transform.parent = _buttonCubes.transform.GetChild(2).transform;
            }
            for (int i = 0; i < _cubesCount; i++)
            {
                GameObject _but = Instantiate(_button, new Vector3(_cubes.transform.GetChild((_cubesCount * (_cubesCount-1)+i) ).position.x, 1, _cubes.transform.GetChild((_cubesCount * (_cubesCount-1)) +i).position.z + 1f), Quaternion.Euler(0, 90, 0));
                _but.transform.parent = _buttonCubes.transform.GetChild(1).transform;
            }
            for (int i = 0; i < _cubesCount; i++)
            {
                //GameObject _but = Instantiate(_buton, new Vector3(_cubes.transform.GetChild(i * _cubesCount).position.x - 1.2f, 1, _cubes.transform.GetChild(i * _cubesCount).position.z), Quaternion.identity);
                GameObject _but = Instantiate(_button, new Vector3(_cubes.transform.GetChild(i*_cubesCount).position.x - 1f, 1, _cubes.transform.GetChild(i*_cubesCount).position.z), Quaternion.identity);
                _but.transform.parent = _buttonCubes.transform.GetChild(3).transform;
            }
        }
    }

    public void ButtonPoint()
    {
        _buttonPoint = _cubes.transform.GetChild(_cubes.transform.childCount - 1).localPosition.x / 2;
        _twoButton.transform.position = new Vector3(_buttonPoint - 1.5f, 1.0f, -3.0f);
        _threeButton.transform.position = new Vector3(_buttonPoint, 1.0f, -3.0f);
        _fourButton.transform.position = new Vector3(_buttonPoint + 1.5f, 1.0f, -3.0f);
    }

}
