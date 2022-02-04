using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform PlayerTransform;
    public Transform SpawnPoint;
    public GameObject CompetitorBall;

    Rigidbody _rb;
    float _targetManeuver;
    float _smoothing;
    float _followSpeed;
    float _fireRate;
    float _lastFireTime;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _targetManeuver = 0f;
        _smoothing = 1f;
        _followSpeed = 2.5f;
        _fireRate = 2f;
        _lastFireTime = float.NegativeInfinity;

        StartCoroutine(SetTargetManeuver());
    }

    IEnumerator SetTargetManeuver()
    {
        while (true)
        {
            _targetManeuver = _followSpeed * Mathf.Sign(PlayerTransform.position.x - transform.position.x);
            yield return new WaitForSeconds(1.5f);
            _targetManeuver = 0f;
            yield return new WaitForSeconds(1f);
        }
        
    }

    private void FixedUpdate()
    {
        //Debug.Log(_targetManeuver);
        float newManeuver = Mathf.MoveTowards(_rb.velocity.x, _targetManeuver, Time.deltaTime * _smoothing);
        _rb.velocity = new Vector3(newManeuver, 0f, 0f);
        if (_lastFireTime + _fireRate < Time.time)
        {
            _lastFireTime = Time.time;
            Instantiate(CompetitorBall, SpawnPoint.position, SpawnPoint.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("BoundaryLeft"))
        {
            _rb.position = new Vector3(4.0f, _rb.position.y, _rb.position.z);
        }
        else if (other.name.Equals("BoundaryRight"))
        {
            _rb.position = new Vector3(-4.0f, _rb.position.y, _rb.position.z);
        }
    }
}
