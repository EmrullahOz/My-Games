using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oynanıs : MonoBehaviour
{
    public static oynanıs instance;

    public float angle;
    public float radius;
    public float angleRate;
    public float radiusRate;
    public int ballCount;
    public int ballFark;
    public int limit;

    public GameObject ball;
    public GameObject balls;
    public List<GameObject> kum1 = new List<GameObject>();
    public List<GameObject> kum2 = new List<GameObject>();
    public List<GameObject> kum3 = new List<GameObject>();
    public int xyz;

    

    public Vector3 abc;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //radius = 0.1f;
        //angle = 0.1f;
        if (ballCount != this.transform.childCount)
        {
            xyz = ballCount - this.transform.childCount;


            if (xyz < 0)
            {
                for (int i = 0; i > xyz; i--)
                {
                    if (ballCount == this.transform.childCount)
                    {
                        break;
                    }

                    if (ballCount < this.transform.childCount)
                    {
                        ballFark = this.transform.childCount - ballCount;
                        for (int x = this.transform.childCount - 1; x >= ballFark; x--)
                        {
                            GameObject.Destroy(this.transform.GetChild(x).gameObject);
                        }
                    }
                }

            }
            

            for (int i = 0; i < xyz; i++)
            {

                angle += Mathf.Pow(angleRate, angle * 3);
                radius += Mathf.Pow(radiusRate, radius * 3);

                //angle += angleRate;
                //radius += radiusRate;

                //GameObject b = Instantiate(ball);
                //b.transform.parent = this.transform;

                 GameObject b = Instantiate(ball);
                 b.transform.parent = this.transform;
                 kum1.Add(b); 
                 b.transform.position = new Vector3(((Mathf.Cos(angle) + 0) * radius) + (transform.position.x), (Mathf.Sin(angle) + transform.position.y) * radius, this.transform.position.z);


                //if (ballCount >= limit && ballCount <= limit * 2)
                //{
                //    if (kum1.Count < limit)
                //    {
                //        GameObject b = Instantiate(ball);
                //        b.transform.parent = this.transform;
                //        kum1.Add(b);
                //        b.transform.position = new Vector3(((Mathf.Cos(angle) + 0) * radius) + (transform.position.x), (Mathf.Sin(angle) + transform.position.y) * radius, this.transform.position.z);
                //    }
                //    else
                //    {
                //        GameObject c = Instantiate(ball);
                //        c.transform.parent = this.transform;
                //        kum2.Add(c);
                //        c.transform.position = new Vector3(((Mathf.Cos(angle) + 0) * radius) + (transform.position.x), (Mathf.Sin(angle) + transform.position.y) * radius, this.transform.position.z - 0.4f);
                //    }

                //}

                //if (ballCount >= limit * 2)
                //{
                //    if (kum2.Count < limit)
                //    {
                //        GameObject c = Instantiate(ball);
                //        c.transform.parent = this.transform;
                //        kum2.Add(c);
                //        c.transform.position = new Vector3(((Mathf.Cos(angle) + 0) * radius) + (transform.position.x), (Mathf.Sin(angle) + transform.position.y) * radius, this.transform.position.z - 0.4f);
                //    }
                //    else
                //    {
                //        GameObject d = Instantiate(ball);
                //        d.transform.parent = this.transform;
                //        kum3.Add(d);
                //        d.transform.position = new Vector3(((Mathf.Cos(angle) + 0) * radius) + (transform.position.x), (Mathf.Sin(angle) + transform.position.y) * radius, this.transform.position.z - 0.8f);
                //    }

                //}

                //b.transform.position = new Vector3(((Mathf.Cos(angle) + 0) * radius) + (transform.position.x), (Mathf.Sin(angle) + transform.position.y) * radius, this.transform.position.z);

                transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().enabled = false;
                transform.GetChild(0).GetChild(1).GetComponent<MeshRenderer>().enabled = false;
                transform.GetChild(0).GetChild(2).GetComponent<MeshRenderer>().enabled = false;

                if (ballCount == this.transform.childCount)
                {
                    break;
                }
            }
        }

        if (ballCount <= 100)
        {
            radiusRate = 0.025f;
        }
        else if (100 < ballCount && ballCount <= 200)
        {
            radiusRate = 0.035f;
        }
        else if (200 < ballCount && ballCount <= 300)
        {
            radiusRate = 0.04f;
        }
        else if (300 < ballCount && ballCount <= 400)
        {
            radiusRate = 0.045f;
        }
        else if (400 < ballCount && ballCount <= 500)
        {
            radiusRate = 0.05f;
        }
        else if (500 < ballCount && ballCount <= 600)
        {
            radiusRate = 0.055f;
        }
        else if (600 < ballCount && ballCount <= 800)
        {
            radiusRate = 0.06f;
        }
        else if (800 < ballCount && ballCount <= 1000)
        {
            radiusRate = 0.065f;
        }
        else if (1500 < ballCount && ballCount <= 2500)
        {
            radiusRate = 0.07f;
        }
        else if (2500 < ballCount && ballCount <= 5000)
        {
            radiusRate = 0.075f;
        }
        else if (5000 < ballCount)
        {
            radiusRate = 0.08f;
        }
    }
    IEnumerator SpawnTime()
    {
        GameObject b = Instantiate(ball);

        b.transform.parent = this.transform;
        b.transform.position = new Vector3(((Mathf.Cos(angle) + 0) * radius) + (transform.position.x), (Mathf.Sin(angle) + transform.position.y) * radius, this.transform.position.z);

        yield return new WaitForSeconds(0.01f);

    }
}
