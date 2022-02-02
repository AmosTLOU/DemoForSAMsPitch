using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public GameObject VFXGetTarget;
    
    AudioSource _audio;
    Rigidbody _rb;
    Transform _tf;
    float _speed;

    // Start is called before the first frame update
    void Start()
    {
        _audio = FindObjectOfType<AudioSource>();
        _speed = 5f;
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = Vector3.forward * _speed;
        _tf = GetComponent<Transform>();
        
    }


    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.name.Equals("BoundaryTop"))
    //    {
    //        Destroy(gameObject);
    //    }
        
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("TargetBall"))
        {
            _audio.Play();
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Instantiate(VFXGetTarget, _tf.position, _tf.rotation);
        }
        if (collision.gameObject.CompareTag("WallHorizontal") || collision.gameObject.CompareTag("WallVertical"))
        {
            Destroy(gameObject);
        }
    }
}
