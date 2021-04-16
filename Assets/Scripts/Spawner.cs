using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Properties

    public List<Transform> SpawnPointList = null;
    public GameObject EnemyPrefab = null;

    public float SpawnPeriod;

    private float _nextSpawnTime;

    #endregion

    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        if (Time.time >= _nextSpawnTime)
        {
            SpawnEnemy();

            _nextSpawnTime = Time.time + SpawnPeriod;
        }
    }

    private void Initialize()
    {
        _nextSpawnTime = 0f;
    }

    private void SpawnEnemy()
    {
        Vector3 _randomPosition = SpawnPointList[Random.Range(0, SpawnPointList.Count)].position + new Vector3(0, 1, 0);
        Instantiate(EnemyPrefab, _randomPosition, Quaternion.identity);
    }
}
