using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerLevelControl_V2 : MonoBehaviour
{

    Light _light;

    // Start is called before the first frame update
    void Start()
    {
        _light = FindObjectOfType<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        _light.intensity = 1f + GameStateManager_V2.s_dangerLevel * 9f;
    }
}
