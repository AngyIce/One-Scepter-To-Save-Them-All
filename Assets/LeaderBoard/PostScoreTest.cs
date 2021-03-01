using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PostScoreTest : MonoBehaviour
{
    public static PostScoreTest Singleton;

    public string DreamloLink = "http://dreamlo.com/lb/qSjVpoFLT0G7H38zsZkJvQiGLL6LwiakK5YaNJt3lIzA";
    public static string PlayerName;
    public float tempScore;   
    public List<ScoreEntry> ScoreBoardEntries = new List<ScoreEntry>();

    public UnityEvent ScoreBoardUpdatedEvent;

    private void OnEnable()
    {
        Singleton = this;
    }

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PostNewScore(PlayerName, ScorePoints.scoreValue);
        }
    }

    public void PostNewScore(string playerName, float score)
    {      
        StartCoroutine(PostScoreEnumerator(playerName, score));
        PlayerName = playerName;
        tempScore = ScorePoints.scoreValue;
        tempScore = score;
    }

    IEnumerator PostScoreEnumerator(string playerName, float score)
    {
        string myUrl = DreamloLink + "/add/" + playerName + "/" + score.ToString();
        using (WWW loadedWebsite = new WWW(myUrl))
        {
            yield return loadedWebsite;
            if (loadedWebsite.text.Contains("OK"))
            {
                print("Caricamento Completato");
            }
            StartCoroutine(GetScoreBoardEnumerator());
        }
    }

    IEnumerator GetScoreBoardEnumerator()
    {
        //Creating the URL to get the ScoreBoard
        string myUrl = DreamloLink + "/quote";
        //Cleaning UP old Values in the list (I forgot to do this during the lesson, this is why it was not working)
        ScoreBoardEntries.Clear();

        using (WWW loadedWebsite = new WWW(myUrl))
        {
            yield return loadedWebsite;
            string pageContent = loadedWebsite.text;
            string[] pageContentLines = pageContent.Split('\n');

            for (int i = 0; i < pageContentLines.Length; i++)
            {
                if (!string.IsNullOrEmpty(pageContentLines[i]))
                {
                    string[] lineContent = pageContentLines[i].Split(',');

                    string myPlayerName = QuotedStringCleanup(lineContent[0]);
                    int myScore = int.Parse(QuotedStringCleanup(lineContent[1]));

                    ScoreBoardEntries.Add(new ScoreEntry(myPlayerName, myScore));
                }
            }   
        }
        yield return new WaitForFixedUpdate();
        ScoreBoardUpdatedEvent.Invoke();
    }

    string QuotedStringCleanup(string rawString)
    {
        string tempString = rawString.Substring(1, rawString.Length - 2);
        return tempString;
    }
}

public class ScoreEntry
{
    public string PlayerName;
    public int PlayerScore;

    public ScoreEntry(string playerName,int playerScore)
    {
        PlayerName = playerName;
        PlayerScore = playerScore;
    }
}
