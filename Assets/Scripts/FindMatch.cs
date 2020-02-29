using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMatch : MonoBehaviour
{
    NumberOfClick numberOfClick;
    Tile tile;
    Board board;
    List<Tile> tiles = new List<Tile>();

    private void Start()
    {
        numberOfClick = new NumberOfClick();
        board = FindObjectOfType<Board>();
        tile = new Tile();
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

    private void Array()
    {
        if (tiles.Count < 3 && tiles.Count > 0)
        {
            NumberOfClick.numsClick--;
            numberOfClick.ClickToMouse();
        }
        else if (tiles.Count == 4)
        {
            NumberOfClick.numsClick++;
            numberOfClick.ClickToMouse();
        }
        else if (tiles.Count >= 5)
        {
            NumberOfClick.numsClick += 2;
            numberOfClick.ClickToMouse();
        }
        tiles.Clear();
    }

    
}
