using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowUI : MonoBehaviour
{
    public Transform TransformFollowee;

    Vector3 positionOffset;

    // Start is called before the first frame update
    void Start()
    {
        positionOffset = transform.position - TransformFollowee.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = TransformFollowee.position + positionOffset;
    }
}
