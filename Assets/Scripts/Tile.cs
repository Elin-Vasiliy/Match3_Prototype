using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tile : MonoBehaviour
{
    [SerializeField] private int point;

    public bool isDelete = false;
    public Menu PopupMenu;

    private ParticleSystem particle;
    private Board board;
    private FindMatch findMatch;
    private int column;
    private int row;

    public int Column
    {
        get
        {
            return column;
        }
        set
        {
            column = value;
        }
    }
    public int Row
    {
        get
        {
            return row;
        }
        set
        {
            row = value;
        }
    }
    public int Points => point;

    private void Start()
    {
        findMatch = FindObjectOfType<FindMatch>();
        board = FindObjectOfType<Board>();
        PopupMenu = FindObjectOfType<Menu>();
    }

    private void OnMouseDown()
    {
        if (!board.isMatch && !PopupMenu.isMenu && findMatch.nums > 0)
        {
            isDelete = true;
            CheckAdjacentTiles(this);
        }
    }

    private void Check()
    {
        if (board.tileArray[column, row].column < board.xSize - 1 && board.tileArray[column, row].column > 0)
        {
            if (board.tileArray[column + 1, row] != null && board.tileArray[column + 1, row].tag == this.gameObject.tag && board.tileArray[column + 1, row].GetComponent<Tile>().isDelete != true)
            {
                CheckAdjacentTiles(board.tileArray[column + 1, row]);
            }
            if (board.tileArray[column - 1, row] != null && board.tileArray[column - 1, row].tag == this.gameObject.tag && board.tileArray[column - 1, row].GetComponent<Tile>().isDelete != true)
            {
                CheckAdjacentTiles(board.tileArray[column - 1, row]);
            }
        }
        else if (board.tileArray[column, row].column == 0 || board.tileArray[column, row].column == board.xSize - 1)
        {
            if (board.tileArray[column, row].column == 0)
            {
                if (board.tileArray[column + 1, row] != null && board.tileArray[column + 1, row].tag == this.gameObject.tag && board.tileArray[column + 1, row].isDelete != true)
                {
                    CheckAdjacentTiles(board.tileArray[column + 1, row]);
                }
            }
            if (board.tileArray[column, row].column == board.xSize - 1)
            {
                if (board.tileArray[column - 1, row] != null && board.tileArray[column - 1, row].tag == this.gameObject.tag && board.tileArray[column - 1, row].isDelete != true)
                {
                    CheckAdjacentTiles(board.tileArray[column - 1, row]);
                }
            }
        }
        if (board.tileArray[column, row].row < board.ySize - 1 && board.tileArray[column, row].row > 0)
        {
            if (board.tileArray[column, row + 1] != null && board.tileArray[column, row + 1].tag == this.gameObject.tag && board.tileArray[column, row + 1].isDelete != true)
            {
                CheckAdjacentTiles(board.tileArray[column, row + 1]);
            }
            if (board.tileArray[column, row - 1] != null && board.tileArray[column, row - 1].tag == this.gameObject.tag && board.tileArray[column, row - 1].isDelete != true)
            {
                CheckAdjacentTiles(board.tileArray[column, row - 1]);
            }
        }
        else if (board.tileArray[column, row].row == 0 || board.tileArray[column, row].row == board.ySize - 1)
        {
            if (board.tileArray[column, row].row == 0)
            {
                if (board.tileArray[column, row + 1] != null && board.tileArray[column, row + 1].tag == this.gameObject.tag && board.tileArray[column, row + 1].isDelete != true)
                {
                    CheckAdjacentTiles(board.tileArray[column, row + 1]);
                }
            }
            if (board.tileArray[column, row].row == board.ySize - 1)
            {
                if (board.tileArray[column, row - 1] != null && board.tileArray[column, row - 1].tag == this.gameObject.tag && board.tileArray[column, row - 1].isDelete != true)
                {
                    CheckAdjacentTiles(board.tileArray[column, row - 1]);
                }
            }
        }
    }

    private void DeleteTile(GameObject gameObject)
    {
        board.Particle.Play();
        Destroy(gameObject);
    }

    private void CheckAdjacentTiles(Tile tile)
    {
        tile.isDelete = true;
        tile.Check();
        findMatch.AddList(tile);
        DeleteTile(tile.gameObject);
    }
}
