using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public GameObject TargetBall;
    public GameObject CompetitorBall;
    public Transform BoundaryLeftSpawn;
    public Transform BoundaryRightSpawn;

    float _spawnRate;
    float _lastSpawnTime;
    bool _lastSpawnType;

    // Start is called before the first frame update
    void Start()
    {
        _spawnRate = 1.5f;
        _lastSpawnTime = float.NegativeInfinity;
        _lastSpawnType = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(_lastSpawnTime + _spawnRate < Time.time)
        {
            _lastSpawnTime = Time.time;
            float xSpawn = Random.Range(BoundaryLeftSpawn.position.x, BoundaryRightSpawn.position.x);
            Vector3 posSpawn = new Vector3(xSpawn, 0f, BoundaryLeftSpawn.position.z);
            if(_lastSpawnType)
                Instantiate(TargetBall, posSpawn, BoundaryLeftSpawn.rotation);
            else
                Instantiate(CompetitorBall, posSpawn, BoundaryLeftSpawn.rotation);
            _lastSpawnType = !_lastSpawnType;
        }
    }
}
