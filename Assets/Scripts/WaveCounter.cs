using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveCounter : MonoBehaviour
{
    public static int waveCount = 1;

    Text Wave;

    void Start()
    {
        Wave = GetComponent<Text>();
        waveCount = 1;
    }

    void Update()
    {
        Wave.text = "wave " + waveCount;
    }
}
