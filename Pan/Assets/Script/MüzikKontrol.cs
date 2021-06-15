using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MüzikKontrol : MonoBehaviour
{
    static MüzikKontrol MüzikOynatıcısı;

    private void Awake()
    {
        if (MüzikOynatıcısı != null)
        {
            Destroy(gameObject);
        }
        else
        {
            MüzikOynatıcısı = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
