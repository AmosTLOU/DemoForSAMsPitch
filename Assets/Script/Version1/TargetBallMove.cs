using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBallMove : MonoBehaviour
{
    float _speed;

    // Start is called before the first frame update
    void Start()
    {
        _speed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = transform.position;
        movement.z -= Time.deltaTime * _speed;
        transform.position = movement;
    }
}
