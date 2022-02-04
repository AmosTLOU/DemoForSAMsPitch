using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveControl : MonoBehaviour
{
    public GameObject Bullet;
    public Transform SpawnPoint;
    public Slider BulletRemain;
    public AudioSource Audio;

    Rigidbody _rigidbody;
    float _speedHorizontalOriginal;
    float _speedHorizontal;
    float _speedTilt;
    float _maxTiltAngle;
    float _fireRate;
    float _lastFireTime;
    float _cntBulletRemain;
    float _maxBullet;
    float _supplyRate;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _speedHorizontalOriginal = 10f;
        _speedHorizontal = _speedHorizontalOriginal;
        _speedTilt = 10f;
        _maxTiltAngle = 35f;
        _fireRate = 0.5f;
        _lastFireTime = float.NegativeInfinity;
        _cntBulletRemain = _maxBullet = 100f;
        BulletRemain.value = _cntBulletRemain / _maxBullet;
        _supplyRate = 2f;
    }


    void FixedUpdate()
    {
        if (GameStateManager.s_gameEnd)
        {
            _rigidbody.velocity = Vector3.zero;
            transform.eulerAngles = Vector3.zero;
            return;
        }

        float level = GameStateManager.s_dangerLevel;
        _speedHorizontal = _speedHorizontalOriginal - level * 30f;
        _speedHorizontal = Mathf.Max(_speedHorizontal, 1f);
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        _rigidbody.velocity = _speedHorizontal * movement;

        float rotation_z = Mathf.Clamp(_rigidbody.velocity.x * -_speedTilt, -_maxTiltAngle, _maxTiltAngle);
        transform.eulerAngles = new Vector3(0f, 0f, rotation_z);
    }

    private void Update()
    {
        if (GameStateManager.s_gameEnd)
            return;

        if (Input.GetButton("Fire1"))
        {
            if (_lastFireTime + _fireRate < Time.time && 0 < _cntBulletRemain)
            {
                _lastFireTime = Time.time;
                _cntBulletRemain -= 10;
                Audio.Play();
                Instantiate(Bullet, SpawnPoint.position, SpawnPoint.rotation);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            _cntBulletRemain += (_maxBullet / 2);
        }
        else if (Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadScene(0);
        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {
            SceneManager.LoadScene(1);
        }
        _cntBulletRemain += _supplyRate * Time.deltaTime;
        _cntBulletRemain = Mathf.Min(_cntBulletRemain, _maxBullet);
        BulletRemain.value = _cntBulletRemain / _maxBullet;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("BoundaryLeft"))
        {
            _rigidbody.position = new Vector3(4.0f, _rigidbody.position.y, _rigidbody.position.z);
        }
        else if(other.name.Equals("BoundaryRight"))
        {
            _rigidbody.position = new Vector3(-4.0f, _rigidbody.position.y, _rigidbody.position.z);
        }
    }

}
