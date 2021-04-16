using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCameraController : MonoBehaviour
{
    #region Properties

    public Transform Player;
    private Vector3 m_Offset;
    private Transform m_MyTransform;

    #endregion

    private void Start()
    {
        Initialize();
    }

    private void LateUpdate()
    {
        m_MyTransform.position = Player.position - m_Offset;
        m_MyTransform.LookAt(Player);
    }

    private void Initialize()
    {
        m_MyTransform = transform;
        m_Offset = Player.position - m_MyTransform.position;
    }
}