using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraKontrol : MonoBehaviour
{
    public Vector3 mesafe;
    public GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        mesafe = transform.position - Target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Target.transform.position + mesafe, 0.3f);
    }
}
