﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FindMatch : MonoBehaviour
{
    public TMP_Text NumberOfMoves, ScoreText, RecordText;
    public int nums = 5;
    public GameObject PopupGameOver;

    private Tile tile = new Tile();
    private List<Tile> tiles = new List<Tile>();
    private int score = 0;
    private int raisingScore = 1;
    public int ScoreRecord;

    public int Score { get => score; set => score = value; }

    private void Start()
    {
        NumberOfMoves.text = $"Move count: {nums}";
        ScoreText.text = $"Score: {Score}";
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Array();
        }
    }

    public void AddList(Tile tile)
    {
        if (!tiles.Contains(tile))
        {
            tiles.Add(tile);
        }
    }

    public void Array()
    {
        if(tiles.Count < 3 && tiles.Count > 0)
        {
            nums--;
        }
        else if (tiles.Count == 4)
        {
            nums++;
        }
        else if (tiles.Count > 5 && tiles.Count < 8)
        {
            nums += 2;
            raisingScore = 2;
        }
        else if (tiles.Count >= 8)
        {
            nums += 3;
            raisingScore = 3;
        }
        NumberOfMoves.text = $"Move count: {nums}";
        foreach (var item in tiles)
        {
            Score += item.Points * raisingScore;
        }
        ScoreText.text = $"Score: {Score}";

        tiles.Clear();
        raisingScore = 1;
        if (nums == 0)
        {
            AudioManager.instance.PlaySFX(Clip.GameOver);
        }
        StartCoroutine(ScoreGame());
    }

    IEnumerator ScoreGame()
    {
        if (nums == 0)
        {
            yield return new WaitForSeconds(1.5f);
            if (score > PlayerPrefs.GetInt("Score"))
            {
                PlayerPrefs.SetInt("Score", score);
                PlayerPrefs.Save();
                RecordText.gameObject.SetActive(true);
                RecordText.text = $"New Record: \n{PlayerPrefs.GetInt("Score").ToString()}!";
            }
            PopupGameOver.SetActive(true);
        }
    }
}
