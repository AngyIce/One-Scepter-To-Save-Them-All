using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public int countdownTime;
    public Text countndownDisplay;
    public static bool onemoretime = false;

    private void Start()
    {
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {
        while(countdownTime > 0)
        {
            countndownDisplay.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        countndownDisplay.text = "START";

        GameController.instance.SpawnAction();
        GameController.instance.BeginGame();

        yield return new WaitForSeconds(0.5f);

        countndownDisplay.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        if(GameController.beginRestart == true && onemoretime == false)
        {
            countdownTime = 5;
            countndownDisplay.gameObject.SetActive(true);

            StartCoroutine(CountdownToStart());

            onemoretime = true;
        }
    }
}
