using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalBadBallMove : MonoBehaviour
{
   Slider _dangerLevel;

    Rigidbody _rb;
    Transform _tf;
    
    void AssignVelocity(bool xChanged = false, bool zChanged = false)
    {
        float xSpeed = Random.Range(0.6f, 0.8f);
        float zSpeed = -Random.Range(1f, 1.2f);
        if (xChanged)
        {
            if (0 < _rb.velocity.x)
            {
                xSpeed = -xSpeed;
            }
            else if (_rb.velocity.x == 0)
            {
                int randomResult = Random.Range(0, 1);
                if (randomResult == 1)
                {
                    xSpeed = -xSpeed;
                }
            }
        }
        if (zChanged)
        {
            if (_rb.velocity.z < 0)
                zSpeed = -zSpeed;
            
        }
        _rb.velocity = new Vector3(xSpeed, 0f, zSpeed);
    }

    // Start is called before the first frame update
    void Start()
    {
        _dangerLevel = FindObjectOfType<Slider>();

        _rb = GetComponent<Rigidbody>();
        AssignVelocity();
        _tf = GetComponent<Transform>();

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
        if (collision.gameObject.CompareTag("WallVertical"))
        {
            AssignVelocity(true, false);
        }
        else if (collision.gameObject.CompareTag("WallHorizontal"))
        {
            AssignVelocity(false, true);
        }
        else
        {
            AssignVelocity(true, false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Container")
        {
            Destroy(gameObject);
            float level = _dangerLevel.value;
            level += 0.1f;
            _dangerLevel.value = level;
            if (Mathf.Abs(GameStateManager.s_dangerLevelToEndGame - level) <= 0.01f)
                GameStateManager.s_gameEnd = true;
        }
    }
}
