using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompetitorBallMove : MonoBehaviour
{

    public GameObject FinalBadBall;

    Rigidbody _rb;
    Transform _tf;

    int _cntHitWalls;
    int _MaxTimeHitWalls;

    void AssignVelocity(bool xChanged=false, bool zChanged=false)
    {
        float xSpeed = Random.Range(0.8f, 1f);
        float zSpeed = -Random.Range(0.8f, 1f);
        if (xChanged)
        {
            if (0 < _rb.velocity.x)
            {
                xSpeed = -xSpeed;
            }                
            else if(_rb.velocity.x == 0)
            {
                int randomResult = Random.Range(0, 1);
                if(randomResult == 1)
                {
                    xSpeed = -xSpeed;
                }
            }
        }
        if (zChanged)
        {
            if (_rb.velocity.z < 0)
                zSpeed = -zSpeed;
            //else if (_rb.velocity.z == 0)
            //{
            //    int randomResult = Random.Range(0, 1);
            //    if (randomResult == 1)
            //    {
            //        zSpeed = -zSpeed;
            //    }
            //}
        }
        _rb.velocity = new Vector3(xSpeed, 0f, zSpeed);
    }

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        AssignVelocity();
        _tf = GetComponent<Transform>();
        _MaxTimeHitWalls = 20;
    }

    private void Update()
    {
        if (_rb.velocity.magnitude < 0.2)
        {
            AssignVelocity();
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("TargetBall"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Instantiate(FinalBadBall, _tf.position, _tf.rotation);
        }
        else if(collision.gameObject.CompareTag("WallVertical"))
        {
            _cntHitWalls++;
            if (_cntHitWalls == _MaxTimeHitWalls)
                Destroy(gameObject);
            AssignVelocity(true, false);
        }
        else if (collision.gameObject.CompareTag("WallHorizontal"))
        {
            _cntHitWalls++;
            if (_cntHitWalls == _MaxTimeHitWalls)
                Destroy(gameObject);
            AssignVelocity(false, true);
            //if (collision.gameObject.name == "WallBottom")
            //    _enterContainer = true;
        }
        else
        {
            AssignVelocity(true, true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("OneWayWallHorizontal"))
        {
            AssignVelocity(false, true);
        }
        
    }
}
