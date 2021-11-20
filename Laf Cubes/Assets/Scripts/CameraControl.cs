using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private float _loc;
    public float _cameraHeight;

    // Start is called before the first frame update
    void Start()
    {
        //_loc = 0.5f * (Control.instance._cubesCount-1);
        //transform.position = new Vector3(_loc, 12, _loc);

        _loc = Control.instance._cubes.transform.GetChild(Control.instance._cubes.transform.childCount - 1).localPosition.x / 2;
        if (Control.instance._cubesCount<=5)
        {
            transform.position = new Vector3(_loc, _cameraHeight, _loc);
        }
        if (Control.instance._cubesCount>5 && Control.instance._cubesCount <= 8)
        {
            transform.position = new Vector3(_loc, _cameraHeight+3f, _loc);
        }
        if (Control.instance._cubesCount>8 && Control.instance._cubesCount <= 10)
        {
            transform.position = new Vector3(_loc, _cameraHeight+7f, _loc);
        }
        if (Control.instance._cubesCount>10 )
        {
            transform.position = new Vector3(_loc, _cameraHeight+8f, _loc);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
