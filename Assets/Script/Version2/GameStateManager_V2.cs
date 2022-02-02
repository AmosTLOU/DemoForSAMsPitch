using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager_V2 : MonoBehaviour
{
    public GameObject GoGameStart;
    public GameObject GoGameOver;

    public static float s_lightIntensityToEndGame;
    public static bool s_gameEnd;

    IEnumerator ShowForAWhile(GameObject go, float timeToShow)
    {
        go.SetActive(true);
        yield return new WaitForSeconds(timeToShow);
        go.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        s_lightIntensityToEndGame = 8f;
        s_gameEnd = false;
        StartCoroutine(ShowForAWhile(GoGameStart, 3f));
        GoGameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (s_gameEnd)
            GoGameOver.SetActive(true);
    }
}
