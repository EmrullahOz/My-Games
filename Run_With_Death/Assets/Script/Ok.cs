using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ok : MonoBehaviour
{
    //public GameObject ok;
    public GameObject býcak;
    public GameObject player;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 yon=new Vector3(player.transform.position.x,0,0);
            Instantiate(býcak, player.transform.position+new Vector3(player.transform.position.x,1f,transform.position.z)-yon,Quaternion.identity );

            //int sayi = Random.Range(0, 10);
            //if (sayi<5)
            //{
            //    Instantiate(ok, transform.position, Quaternion.identity);

            //}
            //else if (sayi>=5)
            //{
            //    Instantiate(býcak, transform.position,Quaternion.identity);

            //}
        }
    }
}
