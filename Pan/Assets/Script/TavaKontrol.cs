using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavaKontrol : MonoBehaviour
{
    public float mesafe1;
    public float mesafe2;
    public float mesafe3;

    public Transform hedef1;
    public Transform hedef2;
    public Transform hedef3;

    public GameObject TavaNesne;

    private float[] Mesafeler;
    public float mesafe0;


    // Start is called before the first frame update
    void Start()
    {
        Mesafeler[0] = mesafe1;
        Mesafeler[1] = mesafe2;
        Mesafeler[2] = mesafe3;

        Mesafeler[3] = mesafe0;
        
    }

    // Update is called once per frame
    void Update()
    {
        mesafe1 = Vector3.Distance(transform.position, hedef1.position);
        mesafe2 = Vector3.Distance(transform.position, hedef2.position);
        mesafe3 = Vector3.Distance(transform.position, hedef3.position);

        

       // Min(Mesafeler);


        foreach (float Kucuk in Mesafeler)
        {
            if (Kucuk < mesafe1)
            {
                mesafe1 = Kucuk;
            }
        }

        mesafe1 = Mesafeler[3];
    }

    public void TavaAt()
    {
        Instantiate(TavaNesne, transform.position, Quaternion.identity);
        TavaNesne.transform.position = Vector3.MoveTowards(TavaNesne.transform.position, hedef2.transform.position, 1f);
    }

    
}
