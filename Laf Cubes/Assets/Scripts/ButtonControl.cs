using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    public static ButtonControl instance;

    private List<GameObject> _cubeList = new List<GameObject>();

    private int _count;
    private int _remainingCubes;
    private int _addedCubes;

    private GameObject _twoCubes;
    private GameObject _threeCubes;
    private GameObject _fourCubes;

    // Start is called before the first frame update
    void Start()
    {
        _twoCubes = Resources.Load<GameObject>("TwoCubes");
        _threeCubes = Resources.Load<GameObject>("ThreeCubes");
        _fourCubes = Resources.Load<GameObject>("FourCubes");
        _count = Control.instance._cubesCount;
        _remainingCubes = Control.instance._cubesCount;
        CreatingButtoncubes();
    }

    // Update is called once per frame
    void Update()
    {
        
        for (int i = 0; i < _remainingCubes; i++)
        {
            if (_cubeList[i].gameObject == null)
            {
                _remainingCubes =i;
                break;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100.0f) )
            {
                if (hit.transform.CompareTag("TwoCubes"))
                {
                    _addedCubes = 2;
                }
                if (hit.transform.CompareTag("ThreeCubes"))
                {
                    _addedCubes = 3;
                }
                if (hit.transform.CompareTag("FourCubes"))
                {
                    _addedCubes = 4;
                }
                if (hit.transform.CompareTag("ButtonCubes"))
                {
                    if (hit.transform.gameObject.transform.parent.name=="Down")
                    {
                        if (hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes>=_addedCubes && _addedCubes==2)
                        {
                            GameObject _block = Instantiate(_twoCubes, new Vector3(hit.transform.gameObject.transform.position.x, hit.transform.gameObject.transform.position.y, hit.transform.gameObject.transform.position.z-(_addedCubes-1)), Quaternion.Euler(0, 0, 0));
                            StartCoroutine(Movement(_block, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes,1));
                            Destroy(hit.transform.gameObject.GetComponent<ButtonControl>()._cubeList[hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes - 1].transform.gameObject, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes * 0.25f);
                            Destroy(hit.transform.gameObject.GetComponent<ButtonControl>()._cubeList[hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes - 2].transform.gameObject, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes * 0.25f);
                        }
                        if (hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes>=_addedCubes && _addedCubes==3)
                        {
                            GameObject _block = Instantiate(_threeCubes, new Vector3(hit.transform.gameObject.transform.position.x, hit.transform.gameObject.transform.position.y, hit.transform.gameObject.transform.position.z-(_addedCubes-1)), Quaternion.Euler(0, 0, 0));
                            StartCoroutine(Movement(_block, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes,1));
                            Destroy(hit.transform.gameObject.GetComponent<ButtonControl>()._cubeList[hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes - 1].transform.gameObject, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes * 0.25f);
                            Destroy(hit.transform.gameObject.GetComponent<ButtonControl>()._cubeList[hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes - 2].transform.gameObject, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes * 0.25f);
                            Destroy(hit.transform.gameObject.GetComponent<ButtonControl>()._cubeList[hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes - 3].transform.gameObject, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes * 0.25f);
                        } 
                        if (hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes>=_addedCubes && _addedCubes==4)
                        {
                            GameObject _block = Instantiate(_fourCubes, new Vector3(hit.transform.gameObject.transform.position.x, hit.transform.gameObject.transform.position.y, hit.transform.gameObject.transform.position.z-(_addedCubes-1)), Quaternion.Euler(0, 0, 0));
                            StartCoroutine(Movement(_block, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes,1));
                            Destroy(hit.transform.gameObject.GetComponent<ButtonControl>()._cubeList[hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes - 1].transform.gameObject, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes * 0.25f);
                            Destroy(hit.transform.gameObject.GetComponent<ButtonControl>()._cubeList[hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes - 2].transform.gameObject, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes * 0.25f);
                            Destroy(hit.transform.gameObject.GetComponent<ButtonControl>()._cubeList[hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes - 3].transform.gameObject, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes * 0.25f);
                            Destroy(hit.transform.gameObject.GetComponent<ButtonControl>()._cubeList[hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes - 4].transform.gameObject, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes * 0.25f);
                        }
                    }
                    if (hit.transform.gameObject.transform.parent.name=="Right")
                    {
                        if (hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes>=_addedCubes && _addedCubes==2)
                        {
                            GameObject _block = Instantiate(_twoCubes, new Vector3(hit.transform.gameObject.transform.position.x+(_addedCubes-1), hit.transform.gameObject.transform.position.y, hit.transform.gameObject.transform.position.z), Quaternion.Euler(0, 270, 0));
                            StartCoroutine(Movement(_block, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes, 2));
                            Destroy(hit.transform.gameObject.GetComponent<ButtonControl>()._cubeList[hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes - 1].transform.gameObject, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes * 0.25f);
                            Destroy(hit.transform.gameObject.GetComponent<ButtonControl>()._cubeList[hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes - 2].transform.gameObject, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes * 0.25f);
                        }
                        if (hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes>=_addedCubes && _addedCubes==3)
                        {
                            GameObject _block = Instantiate(_threeCubes, new Vector3(hit.transform.gameObject.transform.position.x + (_addedCubes - 1), hit.transform.gameObject.transform.position.y, hit.transform.gameObject.transform.position.z), Quaternion.Euler(0, 270, 0));
                            StartCoroutine(Movement(_block, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes, 2));
                            Destroy(hit.transform.gameObject.GetComponent<ButtonControl>()._cubeList[hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes - 1].transform.gameObject, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes * 0.25f);
                            Destroy(hit.transform.gameObject.GetComponent<ButtonControl>()._cubeList[hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes - 2].transform.gameObject, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes * 0.25f);
                            Destroy(hit.transform.gameObject.GetComponent<ButtonControl>()._cubeList[hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes - 3].transform.gameObject, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes * 0.25f);
                        } 
                        if (hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes>=_addedCubes && _addedCubes==4)
                        {
                            GameObject _block = Instantiate(_fourCubes, new Vector3(hit.transform.gameObject.transform.position.x + (_addedCubes - 1), hit.transform.gameObject.transform.position.y, hit.transform.gameObject.transform.position.z), Quaternion.Euler(0, 270, 0));
                            StartCoroutine(Movement(_block, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes, 2));
                            Destroy(hit.transform.gameObject.GetComponent<ButtonControl>()._cubeList[hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes - 1].transform.gameObject, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes * 0.25f);
                            Destroy(hit.transform.gameObject.GetComponent<ButtonControl>()._cubeList[hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes - 2].transform.gameObject, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes * 0.25f);
                            Destroy(hit.transform.gameObject.GetComponent<ButtonControl>()._cubeList[hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes - 3].transform.gameObject, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes * 0.25f);
                            Destroy(hit.transform.gameObject.GetComponent<ButtonControl>()._cubeList[hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes - 4].transform.gameObject, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes * 0.25f);
                        }
                    }
                    if (hit.transform.gameObject.transform.parent.name=="Up")
                    {
                        if (hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes>=_addedCubes && _addedCubes==2)
                        {
                            GameObject _block = Instantiate(_twoCubes, new Vector3(hit.transform.gameObject.transform.position.x, hit.transform.gameObject.transform.position.y, hit.transform.gameObject.transform.position.z+(_addedCubes-1)), Quaternion.Euler(0, 180, 0));
                            StartCoroutine(Movement(_block, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes, 3));
                            Destroy(hit.transform.gameObject.GetComponent<ButtonControl>()._cubeList[hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes - 1].transform.gameObject, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes * 0.25f);
                            Destroy(hit.transform.gameObject.GetComponent<ButtonControl>()._cubeList[hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes - 2].transform.gameObject, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes * 0.25f);
                        }
                        if (hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes>=_addedCubes && _addedCubes==3)
                        {
                            GameObject _block = Instantiate(_threeCubes, new Vector3(hit.transform.gameObject.transform.position.x, hit.transform.gameObject.transform.position.y, hit.transform.gameObject.transform.position.z+(_addedCubes-1)), Quaternion.Euler(0, 180, 0));
                            StartCoroutine(Movement(_block, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes, 3));
                            Destroy(hit.transform.gameObject.GetComponent<ButtonControl>()._cubeList[hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes - 1].transform.gameObject, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes * 0.25f);
                            Destroy(hit.transform.gameObject.GetComponent<ButtonControl>()._cubeList[hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes - 2].transform.gameObject, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes * 0.25f);
                            Destroy(hit.transform.gameObject.GetComponent<ButtonControl>()._cubeList[hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes - 3].transform.gameObject, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes * 0.25f);
                        } 
                        if (hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes>=_addedCubes && _addedCubes==4)
                        {
                            GameObject _block = Instantiate(_fourCubes, new Vector3(hit.transform.gameObject.transform.position.x, hit.transform.gameObject.transform.position.y, hit.transform.gameObject.transform.position.z+(_addedCubes-1)), Quaternion.Euler(0, 180, 0));
                            StartCoroutine(Movement(_block, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes, 3));
                            Destroy(hit.transform.gameObject.GetComponent<ButtonControl>()._cubeList[hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes - 1].transform.gameObject, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes * 0.25f);
                            Destroy(hit.transform.gameObject.GetComponent<ButtonControl>()._cubeList[hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes - 2].transform.gameObject, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes * 0.25f);
                            Destroy(hit.transform.gameObject.GetComponent<ButtonControl>()._cubeList[hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes - 3].transform.gameObject, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes * 0.25f);
                            Destroy(hit.transform.gameObject.GetComponent<ButtonControl>()._cubeList[hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes - 4].transform.gameObject, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes * 0.25f);
                        }
                    }
                    if (hit.transform.gameObject.transform.parent.name=="Left")
                    {
                        if (hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes>=_addedCubes && _addedCubes==2)
                        {
                            GameObject _block = Instantiate(_twoCubes, new Vector3(hit.transform.gameObject.transform.position.x - (_addedCubes - 1), hit.transform.gameObject.transform.position.y, hit.transform.gameObject.transform.position.z), Quaternion.Euler(0, 90, 0));
                            StartCoroutine(Movement(_block, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes, 4));
                            Destroy(hit.transform.gameObject.GetComponent<ButtonControl>()._cubeList[hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes - 1].transform.gameObject, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes * 0.25f);
                            Destroy(hit.transform.gameObject.GetComponent<ButtonControl>()._cubeList[hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes - 2].transform.gameObject, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes * 0.25f);
                        }
                        if (hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes>=_addedCubes && _addedCubes==3)
                        {
                            GameObject _block = Instantiate(_threeCubes, new Vector3(hit.transform.gameObject.transform.position.x - (_addedCubes - 1), hit.transform.gameObject.transform.position.y, hit.transform.gameObject.transform.position.z), Quaternion.Euler(0, 90, 0));
                            StartCoroutine(Movement(_block, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes, 4));
                            Destroy(hit.transform.gameObject.GetComponent<ButtonControl>()._cubeList[hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes - 1].transform.gameObject, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes * 0.25f);
                            Destroy(hit.transform.gameObject.GetComponent<ButtonControl>()._cubeList[hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes - 2].transform.gameObject, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes * 0.25f);
                            Destroy(hit.transform.gameObject.GetComponent<ButtonControl>()._cubeList[hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes - 3].transform.gameObject, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes * 0.25f);
                        } 
                        if (hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes>=_addedCubes && _addedCubes==4)
                        {
                            GameObject _block = Instantiate(_fourCubes, new Vector3(hit.transform.gameObject.transform.position.x - (_addedCubes - 1), hit.transform.gameObject.transform.position.y, hit.transform.gameObject.transform.position.z), Quaternion.Euler(0, 90, 0));
                            StartCoroutine(Movement(_block, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes, 4));
                            Destroy(hit.transform.gameObject.GetComponent<ButtonControl>()._cubeList[hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes - 1].transform.gameObject, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes * 0.25f);
                            Destroy(hit.transform.gameObject.GetComponent<ButtonControl>()._cubeList[hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes - 2].transform.gameObject, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes * 0.25f);
                            Destroy(hit.transform.gameObject.GetComponent<ButtonControl>()._cubeList[hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes - 3].transform.gameObject, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes * 0.25f);
                            Destroy(hit.transform.gameObject.GetComponent<ButtonControl>()._cubeList[hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes - 4].transform.gameObject, hit.transform.gameObject.GetComponent<ButtonControl>()._remainingCubes * 0.25f);
                        }
                    }
                }
            }
        }
    }
    
    public void CreatingButtoncubes()
    {
        if (transform.parent.name=="Down")
        {
            for (int j = 0; j < _count; j++)
            {
                for (int i = 0; i < 1; i++)
                {
                    _cubeList.Add(Control.instance._cubes.transform.GetChild(j*_count+ transform.GetSiblingIndex()).gameObject);
                }
            }         
        }
        if (transform.parent.name=="Up")
        {
            for (int j = 0; j < _count; j++)
            {
                for (int i = 0; i < 1; i++)
                {
                    _cubeList.Add(Control.instance._cubes.transform.GetChild((_count*(_count-1))-(_count*j) + transform.GetSiblingIndex()).gameObject);
                }
            }         
        }
        if (transform.parent.name=="Right")
        {
            for (int j = 0; j < _count; j++)
            {
                for (int i = 0; i < 1; i++)
                {
                    _cubeList.Add(Control.instance._cubes.transform.GetChild(((transform.GetSiblingIndex() + 1)*_count)- 1-j).gameObject);
                }
            }         
        }
        if (transform.parent.name=="Left")
        {
            for (int j = 0; j < _count; j++)
            {
                for (int i = 0; i < 1; i++)
                {
                    _cubeList.Add(Control.instance._cubes.transform.GetChild(((transform.GetSiblingIndex() + 1) * _count) - _count + j).gameObject);
                }
            }         
        }       
    }

    IEnumerator Movement(GameObject obj,int point, int direction)
    {
        if (direction==1)
        {
            for (int i = 0; i < point; i++)
            {
                yield return new WaitForSeconds(0.25f);
                obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z + 1f);
            }
        }if (direction==2)
        {
            for (int i = 0; i < point; i++)
            {
                yield return new WaitForSeconds(0.25f);
                obj.transform.position = new Vector3(obj.transform.position.x-1f, obj.transform.position.y, obj.transform.position.z );
            }
        }if (direction==3)
        {
            for (int i = 0; i < point; i++)
            {
                yield return new WaitForSeconds(0.25f);
                obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z - 1f);
            }
        }if (direction==4)
        {
            for (int i = 0; i < point; i++)
            {
                yield return new WaitForSeconds(0.25f);
                obj.transform.position = new Vector3(obj.transform.position.x+1f, obj.transform.position.y, obj.transform.position.z );
            }
        }    
    }
}
