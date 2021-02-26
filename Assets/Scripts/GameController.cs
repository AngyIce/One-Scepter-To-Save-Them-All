using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public UnityEvent startAction;
    public UnityEvent stopAction;

    public Text timeCounter;
    public bool gamePlaying { get; private set; }
    private float startTime, remainingTime;
    TimeSpan timePlaying;

    public float roundTime;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        gamePlaying = false;
    }

    public void BeginGame()
    {
        gamePlaying = true;
        startTime = Time.time + roundTime;
    }

    private void Update()
    {
        if (gamePlaying == true)
        {
            remainingTime = Time.time - startTime;
            timePlaying = TimeSpan.FromSeconds(remainingTime);

            string timePlayingString = "TIMER " + timePlaying.ToString("mm' : 'ss");
            timeCounter.text = timePlayingString;
        }

        if (remainingTime > 0.0f)
        {
            EndRound();
        }

        if (remainingTime > -10.0f)
        {
            StopAction();
        }
    }

    private void EndRound()
    {
        gamePlaying = false;
    }

    public void SpawnAction()
    {
        startAction.Invoke();
    }

    public void StopAction()
    {
        stopAction.Invoke();
    }
}
