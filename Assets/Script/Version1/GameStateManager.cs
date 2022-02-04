using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public GameObject GoGameStart;
    public GameObject GoGameOver;

    public static float s_dangerLevelToEndGame;
    public static float s_dangerLevel;
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
        s_dangerLevelToEndGame = 1f;
        s_dangerLevel = 0f;
        s_gameEnd = false;
        StartCoroutine(ShowForAWhile(GoGameStart, 3f));
        GoGameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(s_dangerLevelToEndGame - s_dangerLevel) <= 0.01f)
            s_gameEnd = true;
        if (s_gameEnd)
            GoGameOver.SetActive(true);
    }
}
