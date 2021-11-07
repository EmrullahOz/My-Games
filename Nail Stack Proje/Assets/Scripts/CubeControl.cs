using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControl : MonoBehaviour
{
    public GameObject _player;
    public GameObject _parent;
    public int _order;
    int _scrollSpeed=40;
    int _scrollRice=0;

    void Start()
    {
        _player = GameObject.Find("Finger");
        _parent = GameObject.Find("Cubes");
        _order = transform.GetSiblingIndex()+1;
        transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, _player.transform.position.z + _order);
        _scrollRice = (transform.parent.transform.childCount / 5) * 10;
    }

    void Update()
    {
        // Set positions Cubes
        _scrollRice = (transform.parent.transform.childCount / 5) * 10;
        transform.Translate(Vector3.forward * Movement.instance.speedForward * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(_player.transform.position.x, transform.position.y, transform.position.z),(_scrollSpeed+_scrollRice)*Time.deltaTime/_order);

        // when a cube disappears from the middle, other cubes come to fore
        if (_order!= transform.GetSiblingIndex() + 1)
        {
            _order = transform.GetSiblingIndex() + 1;
            transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, _player.transform.position.z + _order);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // Add Cube
        if (other.gameObject.CompareTag("Cube"))
        {
            other.transform.parent = _parent.transform; 
            other.transform.GetComponent<CubeControl>().enabled = true;
            other.transform.tag = "Player";
        }
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
