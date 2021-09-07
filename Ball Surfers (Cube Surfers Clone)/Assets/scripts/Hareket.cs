using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hareket : MonoBehaviour
{
    [SerializeField]
    private float ileriGitmeHizi;
    [SerializeField]
    private float sagaSolaGitmeHizi;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float yatayEksen = Input.GetAxis("Horizontal")*sagaSolaGitmeHizi*Time.deltaTime;
        this.transform.Translate(yatayEksen, 0, ileriGitmeHizi * Time.deltaTime);

        if (transform.position.x<=-3f)
        {
            transform.position= new Vector3(-2.99f, transform.position.y,transform.position.z);

        }
        else if (transform.position.x >= 3f)
        {
            transform.position = new Vector3(2.99f, transform.position.y, transform.position.z);
        }
        
    }

    
}
