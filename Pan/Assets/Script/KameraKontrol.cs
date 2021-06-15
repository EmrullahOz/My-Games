using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraKontrol : MonoBehaviour
{
    Vector3 mesafe;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        mesafe = transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Player.transform.position + mesafe, 1f); 
       // transform.position = Player.transform.position + mesafe;
    }
}
