using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KursunKontrol : MonoBehaviour
{
    

    public TextMeshProUGUI can;

    
    // Start is called before the first frame update
    void Start()
    {
        // Instantiate(kursun, Konum.position, Quaternion.identity);

       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
          


            


       



        }
    }
}
