using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraFollow : MonoBehaviour
{
    /* public Transform target;

     // Start is called before the first frame update
     void Start()
     {

     }

     private void FixedUpdate()
     {
         transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * 3f);
     }

     // Update is called once per frame
     void Update()
     {
         //transform.position = Vector3.Lerp(transform.position, target.position , Time.deltaTime * 3f);
     }*/

    /*
    public Transform Target;
    //camera transform
    public Transform camTransform;
    // offset between camera and target
    public Vector3 Offset;
    // change this value to get desired smoothness
    public float SmoothTime = 0.3f;

    // This value will change at the runtime depending on target movement. Initialize with zero vector.
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        Offset = camTransform.position - Target.position;
    }

    private void LateUpdate()
    {
        // update position
        Vector3 targetPosition = Target.position + Offset;
        camTransform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime);

        // update rotation
        transform.LookAt(Target);
    }*/

    [SerializeField]

    GameObject karakter;
    Vector3 aradakifark;


    // Use this for initialization
    void Start()
    {
        aradakifark = transform.position - karakter.transform.position;

        

        //aradaki farký buluyoruz
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.position = karakter.transform.position + aradakifark;
        
    }
}
