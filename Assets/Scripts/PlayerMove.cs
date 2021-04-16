using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    #region Properties

    public float Speed;
    private Transform m_MyTransform;

    #endregion

    private void Awake()
    {
        Initialize();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        MovementsInputs();
    }

    private void Initialize()
    {
        m_MyTransform = transform;
    }

    private void MovementsInputs()
    {
        Vector3 m_Direction = Vector3.zero;

        if (Input.GetKey(KeyCode.Z))
        {
            m_Direction += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            m_Direction -= Vector3.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            m_Direction += Vector3.right;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            m_Direction -= Vector3.right;
        }

        m_Direction = m_Direction.normalized;
        m_MyTransform.Translate( m_Direction * Time.deltaTime * Speed, Space.World);
    }
}