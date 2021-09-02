using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    public GameObject target;
    public GameObject target1;
    public GameObject target2;
    public Vector3 distance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, target.transform.position + distance, 0.25f);

    }

    IEnumerator SetStart()
    {
        yield return new WaitForSeconds(0.7f);

        target = target1;
    }
}
