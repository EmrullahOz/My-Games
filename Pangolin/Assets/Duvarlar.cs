using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duvarlar : MonoBehaviour
{
    public GameObject player;

    //public GameObject duvarlar;
    public GameObject duvar1;
    public GameObject duvar2;
    public GameObject duvar3;
    public PlayerControl zemin;
    Vector3 yon, yon1, yon2;

    // Start is called before the first frame update
    void Start()
    {
        KlonOlusturma();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void KlonOlusturma()
    {
        

        yon = Vector3.down *0.8f + new Vector3(transform.position.x,transform.position.y,player.transform.position.z+35f);
        
        //yon = Vector3.forward;

        //for (int i = 0; i < 6; i++)
        //{

        //    yon += Vector3.forward * Random.Range(8, 14) ;
        //    GameObject yeniDuvarlar1 = Instantiate(duvar1, duvar1.transform.position + yon, duvar1.transform.rotation);
        //    GameObject yeniDuvarlar2 = Instantiate(duvar2, duvar2.transform.position + yon, duvar2.transform.rotation);
        //    GameObject yeniDuvarlar3 = Instantiate(duvar3, duvar3.transform.position + yon, duvar3.transform.rotation);

        //}
        for (int i = 0; i < 5; i++)
        {


            switch (Random.Range(1, 6))
            {
                case 1:
                    yon += Vector3.forward * Random.Range(8,15);
                    GameObject yeniDuvarlar1 = Instantiate(duvar1, duvar1.transform.position + yon  , duvar1.transform.rotation);
                    GameObject yeniDuvarlar2 = Instantiate(duvar2, duvar2.transform.position + yon  , duvar2.transform.rotation);
                    GameObject yeniDuvarlar3 = Instantiate(duvar3, duvar3.transform.position + yon  , duvar3.transform.rotation);
                    
                    break;
                case 2:
                    yon += Vector3.forward * Random.Range(10, 19);
                    GameObject yeniDuvarlar4 = Instantiate(duvar1, duvar1.transform.position + yon  , duvar1.transform.rotation);
                    GameObject yeniDuvarlar5 = Instantiate(duvar2, duvar3.transform.position + yon  , duvar3.transform.rotation);
                    GameObject yeniDuvarlar6 = Instantiate(duvar3, duvar2.transform.position + yon  , duvar2.transform.rotation);
                    
                    break;
                case 3:
                    yon += Vector3.forward * Random.Range(11, 19);
                    GameObject yeniDuvarlar7 = Instantiate(duvar1, duvar2.transform.position + yon  , duvar2.transform.rotation);
                    GameObject yeniDuvarlar8 = Instantiate(duvar2, duvar1.transform.position + yon , duvar1.transform.rotation);
                    GameObject yeniDuvarlar9 = Instantiate(duvar3, duvar3.transform.position + yon  , duvar3.transform.rotation);
                    
                    break;
                case 4:
                    yon += Vector3.forward * Random.Range(10, 19);
                    GameObject yeniDuvarlar10 = Instantiate(duvar1, duvar2.transform.position + yon , duvar2.transform.rotation);
                    GameObject yeniDuvarlar11 = Instantiate(duvar2, duvar3.transform.position + yon , duvar3.transform.rotation);
                    GameObject yeniDuvarlar12 = Instantiate(duvar3, duvar1.transform.position + yon , duvar1.transform.rotation); 
                    
                    break;
                case 5:
                    yon += Vector3.forward * Random.Range(10, 19);
                    GameObject yeniDuvarlar13 = Instantiate(duvar1, duvar3.transform.position + yon , duvar3.transform.rotation);
                    GameObject yeniDuvarlar14 = Instantiate(duvar2, duvar1.transform.position + yon , duvar1.transform.rotation);
                    GameObject yeniDuvarlar15 = Instantiate(duvar3, duvar2.transform.position + yon , duvar2.transform.rotation); 
                    
                    break;

            }
           

        }
        

    }

}
