using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerField : MonoBehaviour
{
    void Start()
    {
        var input = gameObject.GetComponent<InputField>();
        var se = new InputField.SubmitEvent();
           
        input.onEndEdit.AddListener(SubmitName);
    }

    private void SubmitName(string fieldName)
    {
        PostScoreTest.PlayerName = fieldName;
    }
}
