using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DangerLevelControl : MonoBehaviour
{
    Slider _dangerLevel;

    // Start is called before the first frame update
    void Start()
    {
        _dangerLevel = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        _dangerLevel.value = GameStateManager.s_dangerLevel;
    }
}
