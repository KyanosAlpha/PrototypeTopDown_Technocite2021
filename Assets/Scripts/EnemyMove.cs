using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    #region Properties

    public Transform Player;
    private Transform _transform;

    public float Speed;

    #endregion

    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        Vector3 _target = new Vector3(Player.position.x, _transform.position.y, Player.position.z);
        _transform.LookAt(_target);

        _transform.position += _transform.forward * Time.deltaTime * Speed;
    }

    private void Initialize()
    {
        Player = GameObject.Find("Player").transform;
        _transform = transform;
    }
}
