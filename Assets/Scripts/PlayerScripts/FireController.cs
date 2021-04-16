using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    #region Properties

    public Transform Gun;
    public ParticleSystem MuzzleFlash;
    public ParticleSystem ParticlesImpactPrefabs;
    public Light Fire;
    public TrailRenderer BulletTrailPrefabs;

    public float ShootPeriod;
    private float _nextShootTime;

    private RaycastHit _hit;

    private bool _isHit;

    #endregion

    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        Shoot();
    }

    private void Initialize()
    {
        //Cursor.visible = false;

        _nextShootTime = 0f;
    }

    private void Shoot()
    {
        _isHit = Physics.Raycast(Gun.position, Gun.forward, out _hit);

        if (Input.GetMouseButton(0) && Time.time >= _nextShootTime)
        {
            MuzzleFlash.Play();

            Fire.gameObject.SetActive(true);
            Invoke("SetOffLight", 0.1f);

            TrailRenderer bulletTrail = Instantiate(BulletTrailPrefabs, Gun.position, Quaternion.identity);
            bulletTrail.AddPosition(Gun.position);

            if (_isHit)
            {
                GameObject _hitObject = _hit.collider.gameObject;
                if (LayerMask.LayerToName(_hitObject.layer) == "Destructible")
                {
                    Destroy(_hitObject);
                }

                ParticleSystem ParticlesImpact = Instantiate(ParticlesImpactPrefabs, _hit.point, Quaternion.identity);
                ParticlesImpact.transform.rotation = Quaternion.LookRotation(_hit.normal);
                
                Destroy(ParticlesImpact.gameObject, 0.1f);

                bulletTrail.transform.position = _hit.point;
            }

            _nextShootTime = Time.time + ShootPeriod;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_hit.point, _hit.point + _hit.normal);
    }

    private void SetOffLight()
    {
        Fire.gameObject.SetActive(false);
    }
}