using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    #region Properties

    public float Speed;
    private Transform m_MyTransform;

    private Rigidbody _rigidbody;

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
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void MovementsInputs()
    {
        Vector3 m_Direction = Vector3.zero;

        if (Input.GetKey(KeyCode.Z) && m_MyTransform.position.z < 45)
        {
            m_Direction += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S) && m_MyTransform.position.z > -45)
        {
            m_Direction -= Vector3.forward;
        }
        if (Input.GetKey(KeyCode.D) && m_MyTransform.position.x < 45)
        {
            m_Direction += Vector3.right;
        }
        if (Input.GetKey(KeyCode.Q) && m_MyTransform.position.x > -45)
        {
            m_Direction -= Vector3.right;
        }

        m_Direction = m_Direction.normalized;
        m_MyTransform.Translate( m_Direction * Time.deltaTime * Speed, Space.World);

        _rigidbody.velocity = Vector3.zero;
    }
}