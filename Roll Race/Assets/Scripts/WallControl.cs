using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WallControl : MonoBehaviour
{
    public int _count1;
    public int _count2;
    private int _process1;
    private int _process2;
    public int _processAccount1;    // 1 + , 2 * , 3 - , 4 / 
    public int _processAccount2;    // 1 + , 2 * , 3 - , 4 / 

    private TMP_Text _text1;
    private TMP_Text _text2;

    private Material _wallPos;
    private Material _wallNeg;

    // Start is called before the first frame update
    void Start()
    {
        _wallPos = Resources.Load<Material>("Wall+ Material");
        _wallNeg = Resources.Load<Material>("Wall- Material");
        _text1 = gameObject.transform.GetChild(0).GetChild(0).transform.GetComponent<TextMeshPro>();
        _text2 = gameObject.transform.GetChild(1).GetChild(0).transform.GetComponent<TextMeshPro>();

        //random determination of walls
        _process1 = Random.Range(1, 14);
        if (_process1>=1 && _process1<=5) // +
        {
            gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = _wallPos;
            _count1 = Random.Range(2, 9);
            _text1.text = "+" + _count1.ToString();
            _process2 = Random.Range(1, 14);
            _processAccount1 = 1;
            if (_process2 >= 1 && _process2 <=2 )  //   +
            {
                gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = _wallPos;
                _count2 = Random.Range(2, 9);
                _text2.text = "+" + _count2.ToString();
                _processAccount2 = 1;
            }
            if (_process2 >= 3 && _process2 <=5 )  //   ×
            {
                gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = _wallPos;
                _count2 = Random.Range(2, 4);
                _text2.text = "×" + _count2.ToString();
                _processAccount2 = 2;
            }
            if (_process2 >= 6 && _process2 <=10 )  //   -
            {
                gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = _wallNeg;
                _count2 = Random.Range(1, 5);
                _text2.text = "-" + _count2.ToString();
                _processAccount2 = 3;
            }
            if (_process2 >= 11 && _process2 <=13)  //   ÷
            {
                gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = _wallNeg;
                _count2 = Random.Range(1, 3);
                _text2.text = "÷" + _count2.ToString();
                _processAccount2 = 4;
            }
        }
        if (_process1>=6 && _process1<=8) //  ×
        {
            gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = _wallPos;
            _count1 = Random.Range(2, 4);
            _text1.text = "×" + _count1.ToString();
            _process2 = Random.Range(1, 14);
            _processAccount1 = 2;
            if (_process2 >= 1 && _process2 <= 3)  //   +
            {
                gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = _wallPos;
                _count2 = Random.Range(2, 9);
                _text2.text = "+" + _count2.ToString();
                _processAccount2 = 1;
            }
            if (_process2 >= 4 && _process2 <=4)  //   ×
            {
                gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = _wallPos;
                _count2 = Random.Range(2, 4);
                _text2.text = "×" + _count2.ToString();
                _processAccount2 = 2;
            }
            if (_process2 >= 5 && _process2 <= 8)  //   -
            {
                gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = _wallNeg;
                _count2 = Random.Range(1, 5);
                _text2.text = "-" + _count2.ToString();
                _processAccount2 = 3;
            }
            if (_process2 >= 9 && _process2 <= 13)  //   ÷
            {
                gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = _wallNeg;
                _count2 = Random.Range(1, 3);
                _text2.text = "÷" + _count2.ToString();
                _processAccount2 = 4;
            }
        }
        if (_process1>=9 && _process1<=11) //  -
        {
            gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = _wallNeg;
            _count1 = Random.Range(1, 5);
            _text1.text = "-" + _count1.ToString();
            _process2 = Random.Range(1, 12);
            _processAccount1 = 3;
            if (_process2 >= 1 && _process2 <= 5)  //   +
            {
                gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = _wallPos;
                _count2 = Random.Range(2, 9);
                _text2.text = "+" + _count2.ToString();
                _processAccount2 = 1;
            }
            if (_process2 >= 6 && _process2 <= 9)  //   ×
            {
                gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = _wallPos;
                _count2 = Random.Range(2, 4);
                _text2.text = "×" + _count2.ToString();
                _processAccount2 = 2;
            }
            if (_process2 >= 10 && _process2 <= 10)  //   -
            {
                gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = _wallNeg;
                _count2 = Random.Range(1, 5);
                _text2.text = "-" + _count2.ToString();
                _processAccount2 = 3;
            }
            if (_process2 >= 11 && _process2 <= 11)  //   ÷
            {
                gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = _wallNeg;
                _count2 = Random.Range(1, 3);
                _text2.text = "÷" + _count2.ToString();
                _processAccount2 = 4;
            }
        }
        if (_process1 >= 12 && _process1 <= 13) //  ÷
        {
            gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = _wallNeg;
            _count1 = Random.Range(1, 3);
            _text1.text = "÷" + _count1.ToString();
            _process2 = Random.Range(1, 14);
            _processAccount1 = 4;
            if (_process2 >= 1 && _process2 <= 5)  //   +
            {
                gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = _wallPos;
                _count2 = Random.Range(2, 9);
                _text2.text = "+" + _count2.ToString();
                _processAccount2 = 1;
            }
            if (_process2 >= 6 && _process2 <= 10)  //   ×
            {
                gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = _wallPos;
                _count2 = Random.Range(2, 4);
                _text2.text = "×" + _count2.ToString();
                _processAccount2 = 2;
            }
            if (_process2 >= 11 && _process2 <= 12)  //   -
            {
                gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = _wallNeg;
                _count2 = Random.Range(1, 5);
                _text2.text = "-" + _count2.ToString();
                _processAccount2 = 3;
            }
            if (_process2 >= 13 && _process2 <= 13)  //   ÷
            {
                gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = _wallNeg;
                _count2 = Random.Range(1, 3);
                _text2.text = "÷" + _count2.ToString();
                _processAccount2 = 4;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
