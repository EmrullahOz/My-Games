using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControl : MonoBehaviour
{
    public int _obsNumber;

    private bool _right = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ObstacleMovement();
    }

    //movement system of obstacles
    public void ObstacleMovement()
    {
        if (_obsNumber == 1)
        {
            transform.RotateAround(transform.position, new Vector3(0, 360, 0), 75 * Time.deltaTime);
        }
        if (_obsNumber == 2)
        {
            if (_right)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(3.3f, transform.position.y, transform.position.z), Time.deltaTime * 3);
                if (transform.position.x >= 3)
                {
                    _right = false;
                }
            }
            if (!_right)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(-3.3f, transform.position.y, transform.position.z), Time.deltaTime * 3);
                if (transform.position.x <= -3)
                {
                    _right = true;
                }
            }
        }
        if (_obsNumber == 3)
        {
            if (transform.position.x>=0)
            {
                transform.RotateAround(transform.position, new Vector3(0, 360, 0), -50 * Time.deltaTime);
            }
            if (transform.position.x<0)
            {
                transform.RotateAround(transform.position, new Vector3(0, 360, 0), 50 * Time.deltaTime);
            }            
        }
    }
}
