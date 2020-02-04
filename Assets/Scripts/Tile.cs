using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int column;
    public int row;
    public bool isDelete = false;
    private float time = 0f;

    private Board board;
    private FindMatch findMatch;

    private void Start()
    {
        findMatch = FindObjectOfType<FindMatch>();
        board = FindObjectOfType<Board>();
    }

    private void FixedUpdate()
    {
        //FindMatchTileAll();
    }    

    private void OnMouseDown()
    {
        isDelete = true;
        CheckAdjacentTiles(gameObject.GetComponent<Tile>(), gameObject);
    }

    private void Check()
    {
        if (board.tileArray[column, row].GetComponent<Tile>().column < board.xSize - 1 && board.tileArray[column, row].GetComponent<Tile>().column > 0)
        {
            if (board.tileArray[column + 1, row] != null && board.tileArray[column + 1, row].tag == this.gameObject.tag && board.tileArray[column + 1, row].GetComponent<Tile>().isDelete != true)
            {
                CheckAdjacentTiles(board.tileArray[column + 1, row].GetComponent<Tile>(), board.tileArray[column + 1, row]);
            }
            if (board.tileArray[column - 1, row] != null && board.tileArray[column - 1, row].tag == this.gameObject.tag && board.tileArray[column - 1, row].GetComponent<Tile>().isDelete != true)
            {
                CheckAdjacentTiles(board.tileArray[column - 1, row].GetComponent<Tile>(), board.tileArray[column - 1, row]);
            }
        }
        else if (board.tileArray[column, row].GetComponent<Tile>().column == 0 || board.tileArray[column, row].GetComponent<Tile>().column == board.xSize - 1)
        {
            if (board.tileArray[column, row].GetComponent<Tile>().column == 0)
            {
                if (board.tileArray[column + 1, row] != null && board.tileArray[column + 1, row].tag == this.gameObject.tag && board.tileArray[column + 1, row].GetComponent<Tile>().isDelete != true)
                {
                    CheckAdjacentTiles(board.tileArray[column + 1, row].GetComponent<Tile>(), board.tileArray[column + 1, row]);
                }
            }
            if (board.tileArray[column, row].GetComponent<Tile>().column == board.xSize - 1)
            {
                if (board.tileArray[column - 1, row] != null && board.tileArray[column - 1, row].tag == this.gameObject.tag && board.tileArray[column - 1, row].GetComponent<Tile>().isDelete != true)
                {
                    CheckAdjacentTiles(board.tileArray[column - 1, row].GetComponent<Tile>(), board.tileArray[column - 1, row]);
                }
            }
        }
        if (board.tileArray[column, row].GetComponent<Tile>().row < board.ySize - 1 && board.tileArray[column, row].GetComponent<Tile>().row > 0)
        {
            if (board.tileArray[column, row + 1] != null && board.tileArray[column, row + 1].tag == this.gameObject.tag && board.tileArray[column, row + 1].GetComponent<Tile>().isDelete != true)
            {
                CheckAdjacentTiles(board.tileArray[column, row + 1].GetComponent<Tile>(), board.tileArray[column, row + 1]);
            }
            if (board.tileArray[column, row - 1] != null && board.tileArray[column, row - 1].tag == this.gameObject.tag && board.tileArray[column, row - 1].GetComponent<Tile>().isDelete != true)
            {
                CheckAdjacentTiles(board.tileArray[column, row - 1].GetComponent<Tile>(), board.tileArray[column, row - 1]);
            }
        }
        else if (board.tileArray[column, row].GetComponent<Tile>().row == 0 || board.tileArray[column, row].GetComponent<Tile>().row == board.ySize - 1)
        {
            if (board.tileArray[column, row].GetComponent<Tile>().row == 0)
            {
                if (board.tileArray[column, row + 1] != null && board.tileArray[column, row + 1].tag == this.gameObject.tag && board.tileArray[column, row + 1].GetComponent<Tile>().isDelete != true)
                {
                    CheckAdjacentTiles(board.tileArray[column, row + 1].GetComponent<Tile>(), board.tileArray[column, row + 1]);
                }
            }
            if (board.tileArray[column, row].GetComponent<Tile>().row == board.ySize - 1)
            {
                if (board.tileArray[column, row - 1] != null && board.tileArray[column, row - 1].tag == this.gameObject.tag && board.tileArray[column, row - 1].GetComponent<Tile>().isDelete != true)
                {
                    CheckAdjacentTiles(board.tileArray[column, row - 1].GetComponent<Tile>(), board.tileArray[column, row - 1]);
                }
            }
        }
    }

    private void DeleteTile(GameObject gameObject)
    {
        Destroy(gameObject);
    }

    private void CheckAdjacentTiles(Tile tile, GameObject gameObject)
    {
        tile.isDelete = true;
        tile.Check();
        findMatch.AddList(tile);
        DeleteTile(gameObject);
    }

    public void FindMatchTileAll()
    {
        for (int x = 0; x <= column; x++)
        {
            for (int y = 0; y <= row; y++)
            {
                if (y > 0 && y <= row && board.tileArray[x, y] != null && board.tileArray[x, y - 1] == null)
                {
                    FindMatchTile(x, y);
                }
            }
        }
    }

    private void FindMatchTile(int x, int y)
    {
        //Board.isMatch = true;
        board.tileArray[x, y].transform.position = new Vector2(x, y - 1);
        board.tileArray[x, y].GetComponent<Tile>().row = y - 1;
        board.tileArray[x, y - 1] = board.tileArray[x, y];
        board.tileArray[x, y] = null;
        //Board.isMatch = false;
    }

    //private IEnumerator TileMoveDove(float value)
    //{
    //    yield return StartCoroutine(TileMoveDove(value));
    //    //FindMatchTile();
    //    yield return new WaitForSeconds(value);
    //}
}
