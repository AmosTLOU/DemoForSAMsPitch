using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalBadBallMove_V2 : MonoBehaviour
{
    Light _light;
    Rigidbody _rb;
    Transform _tf;
    float _minSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _light = FindObjectOfType<Light>();
        _rb = GetComponent<Rigidbody>();
        _tf = GetComponent<Transform>();
        _rb.velocity = new Vector3(0f, 0f, -2.5f);
        _minSpeed = 0.2f;
    }

    private void Update()
    {
        
        if (_rb.velocity.magnitude < _minSpeed)
            _rb.velocity = new Vector3(Random.Range(-1, 1) * Random.Range(0, _minSpeed), 0f, Random.Range(0, _minSpeed));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("WallVertical") || collision.gameObject.CompareTag("WallHorizontal"))
        {
            Destroy(gameObject);
            if (!GameStateManager_V2.s_gameEnd)
            {
                if (_light.intensity < 5)
                    _light.intensity += 0.5f;
                else
                    _light.intensity += 1f;
            }            
            if (_light.intensity == GameStateManager_V2.s_lightIntensityToEndGame)
                GameStateManager_V2.s_gameEnd = true;
        }
    }

}
