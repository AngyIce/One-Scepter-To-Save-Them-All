using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScorePoints : MonoBehaviour
{
    public static int scoreValue = 0;
    Text Score;

    void Start()
    {
        Score = GetComponent<Text>();
        scoreValue = 0;
    }

    void Update()
    {
        Score.text = "SCORE " + scoreValue;
    }
}
