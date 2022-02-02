using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompetitorBallMove_V2 : MonoBehaviour
{
    public GameObject FinalBadBall;

    Rigidbody _rb;
    Transform _tf;
    float _speed;

    // Start is called before the first frame update
    void Start()
    {
        _speed = 3.5f;
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = Vector3.back * _speed;
        _tf = GetComponent<Transform>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("TargetBall"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Instantiate(FinalBadBall, _tf.position, _tf.rotation);
        }
        else if (collision.gameObject.CompareTag("WallVertical") || collision.gameObject.CompareTag("WallHorizontal"))
        {
            Destroy(gameObject);
        }
    }
}
