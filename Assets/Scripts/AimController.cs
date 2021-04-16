using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    public Camera MainCamera;
    public Transform Aim;
    private Transform m_MyTransform;

    private void Awake()
    {
        Inizialize();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        Vector3 targetPosition = Vector3.zero;
        Plane plane = new Plane(Vector3.up, Aim.position);
        Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);

        if (plane.Raycast(ray, out float distance))
        {
            targetPosition = ray.GetPoint(distance);
        }
        m_MyTransform.LookAt(new Vector3 (targetPosition.x, m_MyTransform.position.y, targetPosition.z));
    }

    private void Inizialize()
    {
        m_MyTransform = transform;
    }
}