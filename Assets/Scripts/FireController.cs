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

    private RaycastHit _hit;

    private bool _isHit;

    #endregion

    void Start()
    {
        
    }

    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        _isHit = Physics.Raycast(Gun.position, Gun.forward, out _hit);

        if (Input.GetMouseButtonDown(0))
        {
            MuzzleFlash.Play();
            Fire.gameObject.SetActive(true);
            Invoke("SetOffLight", 0.1f);

            if (_isHit)
            {
                ParticleSystem ParticlesImpact = Instantiate(ParticlesImpactPrefabs, _hit.point, Quaternion.identity);
                ParticlesImpact.transform.rotation = Quaternion.LookRotation(_hit.normal);
                
                Destroy(ParticlesImpact.gameObject, 0.1f);
            }
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