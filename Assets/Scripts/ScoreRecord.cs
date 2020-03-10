using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreRecord : MonoBehaviour
{
    public TMP_Text ScoreRecordText;

    private void Start()
    {
        ScoreRecordText.text = $"Record: {PlayerPrefs.GetInt("Score").ToString()}";
    }
}
