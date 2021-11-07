using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class Cut : MonoBehaviour
{
    private Material _mat;
    private GameObject _cutObj;
    public GameObject _head;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Cuttable"))
        {
            _mat = other.GetComponent<MeshRenderer>().material;
            _cutObj = other.gameObject;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (_cutObj!=null)
        {
            SlicedHull Cutk = Cuting(_cutObj, _mat);
            GameObject _cutUp = Cutk.CreateUpperHull(_cutObj, _mat);
            _cutUp.AddComponent<MeshCollider>().convex = true;
            _cutUp.AddComponent<Rigidbody>();
            GameObject _headUp= Instantiate(_head, _cutUp.transform.position, Quaternion.identity);
            //_headUp.transform.parent = _cutUp.transform;
            //_cutUp.layer = LayerMask.NameToLayer("Cuttable");
            GameObject _cutLow = Cutk.CreateLowerHull(_cutObj, _mat);
            _cutLow.AddComponent<MeshCollider>().convex = true;
            _cutLow.AddComponent<Rigidbody>();
            //_cutLow.layer = LayerMask.NameToLayer("Cuttable");
            Destroy(_cutObj);
            //_cutObj.SetActive(false);
            Destroy(_cutUp,2.0f);
            Destroy(_headUp,2.0f);
            Destroy(_cutLow,2.0f);

        }
    }
    
    public SlicedHull Cuting(GameObject obj,Material crossSectionMaterial = null)
    {
        return obj.Slice(transform.position, transform.forward, crossSectionMaterial);
    }
}
