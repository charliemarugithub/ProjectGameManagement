using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private float _timeRemaining;

    public float TimeRemaining
    {
        get { return _timeRemaining; }
        set { _timeRemaining = value; }
    }

    private float maxTime = 60;

    void Start()
    {
        TimeRemaining = maxTime;
    }

    [System.Obsolete]
    void Update()
    {
        TimeRemaining -= Time.deltaTime;

        if (TimeRemaining <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
            TimeRemaining = maxTime;
        }
    }

}
