using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public static Movement instance;

    private float mouseFirstPosX;
    public int speedForward=5;
    private int speedRightLeft=7;
    public float bounders;
    void Start()
    {
        instance = this;
    }   
    void Update()
    {
        transform.Translate(Vector3.forward * speedForward*Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            mouseFirstPosX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x != mouseFirstPosX)
            {
                transform.position = transform.position + transform.right * (Input.mousePosition.x - mouseFirstPosX) / speedRightLeft*Time.deltaTime;
            }
        }
        Bounders();
    }

    // limitation of the character's movements
    public void Bounders()
    {
        Vector3 boundry = transform.position;
        boundry.x = Mathf.Clamp(boundry.x, -bounders, bounders);
        transform.position = boundry;
    }

}
