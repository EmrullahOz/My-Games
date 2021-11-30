using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Gun : MonoBehaviour
{
    public static Gun instance;

    [Header("Guns Tools")]
    public int index;
    public Camera _fpsCam;
    public float _damage;
    public float _range;
    public float _spread;
    public GameObject _pellet;
    public Transform _barrelExit;

    [Header("Particle System")]
    public GameObject _impact;
    public ParticleSystem _Fireimpact;
    public GameObject _impactParent;

    private void Start()
    {
        instance = this;

        _impactParent = GameObject.Find("Impacts");
    }
    void Update()
    {
        // Fire
        if (Input.GetButtonDown("Fire1") && !IsMouseOverUI()) Fire();
        if (Input.GetButton("Fire1") && !IsMouseOverUI() && index == 1) Fire();

        StartCoroutine("Reload");
    }
    
    private void Fire()
    {
        #region Gun
        if (index == 1 && GameManager.instance._gunBulletCount>0)
        {
            GameManager.instance._gunBulletCount--;
            Debug.Log("Ateþ edildi");                        //Ateþ etme (namludan çýkan her merminin “Ateþ edildi” olarak belirtilmesi)
            RaycastHit hit;
            if (Physics.Raycast(_fpsCam.transform.position, _fpsCam.transform.forward, out hit, _range))
            {
                Instantiate(_Fireimpact, _barrelExit.position, Quaternion.identity);
                var Barrel = Instantiate(_pellet, _barrelExit.position, Quaternion.LookRotation(hit.normal));
                Barrel.GetComponent<GunBullet>().target = hit.point;
                var impactEffect = Instantiate(_impact, hit.point, Quaternion.LookRotation(hit.normal));
                impactEffect.transform.parent = _impactParent.transform;
                Destroy(impactEffect.gameObject, 10f);
                if (GameManager.instance._timeBombBullet == false) Destroy(Barrel.gameObject, 0.5f);
                
            }
        }
        #endregion

        #region Shotgun
        if (index == 2 && GameManager.instance._shotGunBulletCount>0)
        {
            _Fireimpact.Play();
            GameManager.instance._shotGunBulletCount--;
            Debug.Log("Ateþ edildi");                         //Ateþ etme (namludan çýkan her merminin “Ateþ edildi” olarak belirtilmesi)
            for (int i = 0; i < GameManager.instance._shotGunBullets; i++)
            {
                Transform t_spawn = _fpsCam.transform;

                Vector3 t_bloom = t_spawn.position + t_spawn.forward * 1000f;
                t_bloom += Random.Range(-_spread, _spread) * t_spawn.up;
                t_bloom += Random.Range(-_spread, _spread) * t_spawn.right;
                t_bloom -= t_spawn.position;
                t_bloom.Normalize();

                for (int a = 0; a < 1; a++)
                {
                    RaycastHit hit = new RaycastHit();
                    if (Physics.Raycast(t_spawn.position, t_bloom, out hit, _range))
                    {
                        var Barrel = Instantiate(_pellet, hit.point + hit.normal * 0.001f, Quaternion.LookRotation(hit.normal)) as GameObject;
                        var impactEffect = Instantiate(_impact, hit.point + hit.normal * 0.001f, Quaternion.LookRotation(hit.normal)) as GameObject;
                        impactEffect.transform.parent = _impactParent.transform;
                        Barrel.transform.LookAt(hit.point + hit.normal);

                        if (GameManager.instance._timeBombBullet == false) Destroy(Barrel.gameObject, 0.5f);

                        Destroy(impactEffect.gameObject, 10f);
                        impactEffect.transform.LookAt(hit.point + hit.normal);
                                            
                    }
                }
            }
        }
        #endregion
    }

    //particle removal system while passing the level
    public void ParticalDeath()
    {
        for (int i = 0; i < _impactParent.transform.childCount; i++)
        {
            Destroy(_impactParent.transform.GetChild(i).gameObject);
        }
    }

    //Function written in UI to not fire when pressing something
    bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    //Automatic reload of the magazine when the ammo runs out
    IEnumerator Reload()
    {
        if (GameManager.instance._gunBulletCount <= 0) 
        {
            Debug.Log("Þarjör boþaldý");
            yield return new WaitForSeconds(2f);
            GameManager.instance._gunBulletCount = 60;
            Debug.Log("Þarjör dolduruldu");
        }
        if (GameManager.instance._shotGunBulletCount <= 0)
        {
            Debug.Log("Þarjör boþaldý");
            yield return new WaitForSeconds(2f);
            GameManager.instance._shotGunBulletCount = 10;
            Debug.Log("Þarjör dolduruldu");
        }
    }
}
