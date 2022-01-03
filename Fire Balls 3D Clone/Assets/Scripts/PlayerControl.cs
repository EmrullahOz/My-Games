using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl instance;

    public int _count=0;

    void Start()
    {
        instance = this;
        Vector3 fark = transform.position - GameManager.instance._cubes[0].transform.position;
        transform.rotation = Quaternion.LookRotation(-fark);
    }

    void Update()
    {
        if (GameManager.instance._cubes[_count].transform.hierarchyCount == 1 )
        {
            GameManager.instance._ingame = false;
            Destroy(GameManager.instance._obstacle[_count].gameObject);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(GameManager.instance._cubes[_count].transform.position.x,transform.position.y, GameManager.instance._cubes[_count].transform.position.z), Time.deltaTime * 6);
            if (transform.position.z== GameManager.instance._cubes[_count].transform.position.z && GameManager.instance._ingame == false)
            {
                _count += 1;
                if (GameManager.instance._cubes.Length==_count)
                {
                    Debug.Log("Success");
                    GameManager.instance._successPanel.SetActive(true);
                }
                else
                {
                    GameManager.instance._obstacle[_count].gameObject.SetActive(true);
                    Vector3 fark = transform.position - GameManager.instance._cubes[_count].transform.position;
                    transform.rotation = Quaternion.LookRotation(-fark);
                    GameManager.instance._bullets.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
                    GameManager.instance._ingame = true;
                }
            }
        }
    }
}
