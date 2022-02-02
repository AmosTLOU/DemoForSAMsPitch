using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBallMove_V2 : MonoBehaviour
{
    float _speed;

    // Start is called before the first frame update
    void Start()
    {
        _speed = 2f;
        if (0 < transform.position.x)
            _speed = -_speed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = transform.position;
        movement.x += Time.deltaTime * _speed;
        transform.position = movement;
    }
}
