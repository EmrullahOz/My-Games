using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour
{
    public Transform Player;
    Vector3 mesafe;

    // Start is called before the first frame update
    void Start()
    {
        mesafe = transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Player.transform.position + mesafe;
    }
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, Player.position+mesafe, Time.deltaTime * 3f);
    }
}
