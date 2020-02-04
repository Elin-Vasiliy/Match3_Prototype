using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int column;
    public int row;
    public bool isDelete = false;

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
        if (!board.isMatch)
        {
            isDelete = true;
            CheckAdjacentTiles(gameObject.GetComponent<Tile>(), gameObject);
        }
        
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
}
