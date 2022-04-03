using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardCarController : MonoBehaviour
{
    public bool _front;
    public bool _right;
    public bool _left;

    void Start()
    {
        
    }
 
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (_front)
            {
                GameManager.instance._carFront.Remove(transform);
            }
            if (_right)
            {
                GameManager.instance._carSideRight.Remove(transform);
            }
            if (_left)
            {
                GameManager.instance._carSideLeft.Remove(transform);
            }
            GameManager.instance._isEnemyCollision = true;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
