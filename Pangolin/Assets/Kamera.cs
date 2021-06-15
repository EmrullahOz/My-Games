using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour
{
    public GameObject Player;
    Vector3 mesafe;
    
    // Start is called before the first frame update
    void Start()
    {
        mesafe = transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position + mesafe;
        //transform.Translate(Vector3.forward + mesafe);
        //transform.position = Vector3.Lerp(transform.position, new Vector3 (0,4.8f,mesafe+Player.transform.position.z), 20f*Time.deltaTime);
    }
}
