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

    #endregion

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MuzzleFlash.Play();
            Fire.gameObject.SetActive(true);
            Invoke("SetOffLight", 0.1f);

            if (Physics.Raycast(Gun.position, transform.forward, out RaycastHit hit))
            {
                ParticleSystem ParticlesImpact = Instantiate(ParticlesImpactPrefabs, hit.point, Quaternion.identity);
                ParticlesImpact.transform.LookAt(hit.normal);

                //Destroy(hit.collider.gameObject);
            }
        }
    }

    private void SetOffLight()
    {
        Fire.gameObject.SetActive(false);
    }
}