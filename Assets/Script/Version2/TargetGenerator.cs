using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGenerator : MonoBehaviour
{
    public GameObject TargetBall;
    public Transform[] SpawnPoints;

    float _spawnRate;
    float _lastTimeSpawn;

    // Start is called before the first frame update
    void Start()
    {
        _spawnRate = 1f;
        _lastTimeSpawn = float.NegativeInfinity;
    }

    // Update is called once per frame
    void Update()
    {
        if(_spawnRate + _lastTimeSpawn < Time.time)
        {
            _lastTimeSpawn = Time.time;
            int range = SpawnPoints.Length;
            int index = Random.Range(0, range);
            Instantiate(TargetBall, SpawnPoints[index].position, SpawnPoints[index].rotation);
        }
    }
}
