using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FindMatch : MonoBehaviour
{
    Tile tile = new Tile();
    List<Tile> tiles = new List<Tile>();
    public TMP_Text numberOfMoves, scoreText;
    private int nums = 30;
    private int score = 0;
    private int raisingScore = 1;

    private void Start()
    {
        numberOfMoves.text = nums.ToString();
        scoreText.text = score.ToString();
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
        if (tiles.Count < 3 && tiles.Count > 0)
        {
            nums--;
        }
        else if (tiles.Count == 4)
        {
            nums++;
        }
        else if (tiles.Count >= 5 && tiles.Count < 7)
        {
            nums += 2;
            raisingScore = 2;
        }
        else if (tiles.Count >= 7)
        {
            nums += 3;
            raisingScore = 3;
        }
        numberOfMoves.text = nums.ToString();
        foreach (var item in tiles)
        {
            score += item.Points * raisingScore;
        }
        scoreText.text = score.ToString();
        tiles.Clear();
        raisingScore = 1;
    }

    
}
