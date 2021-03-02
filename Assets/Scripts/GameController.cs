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
    public static bool onetime;
    public static bool endones;
    public GameObject gameOverPanel;
    public Text timeCounter;
    public GameObject waveCompleted;
    public bool gamePlaying { get; private set; }
    private float startTime, remainingTime;
    public static bool isEnded;
    public static bool isWaveCompleted;
    TimeSpan timePlaying;

    public float roundTime;

    public static bool beginRestart;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        gamePlaying = false;
        isEnded = false;
        onetime = false;
        endones = false;
    }

    public void BeginGame()
    {
        gamePlaying = true;
        beginRestart = false;
        startTime = Time.time + roundTime;
        CountDown.onemoretime = false;
        onetime = false;
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

        /*if (GameObject.Find("Virus(Clone)") == null && isWaveCompleted == true)
        {
            waveCompleted.SetActive(true);
        }*/

        if (remainingTime > 0.0f && onetime == false && GameObject.Find("Virus(Clone)") == null)
        {
            EndRound();
            onetime = true; 
        }

        if (remainingTime > -10.0f)
        {
            StopAction();
        }

        if (remainingTime > 0.0f && GameObject.Find("Virus(Clone)") != null && endones == false)
        {
            EndGame();
            endones = true;
        }

    }

    public void EndRound()
    {
        gamePlaying = false;
        beginRestart = true;
        VirusSpawner.spawnDelay = VirusSpawner.spawnDelay - 1;
        WaveCounter.waveCount = WaveCounter.waveCount += 1;
    }

    public void SpawnAction()
    {
        startAction.Invoke();
    }

    public void StopAction()
    {
        stopAction.Invoke();
    }

    public void EndGame()
    {
        gamePlaying = false;
        Invoke("ShowGameOver", 0.5f);
        isEnded = true;
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
    }
}
