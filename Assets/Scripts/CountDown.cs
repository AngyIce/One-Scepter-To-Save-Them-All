using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public int countdownTime;
    public Text countndownDisplay;

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

        yield return new WaitForSeconds(1f);

        countndownDisplay.gameObject.SetActive(false);

    }
}
