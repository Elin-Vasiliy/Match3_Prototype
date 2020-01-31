using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject[] tile;
    public int xSize, ySize;
    public GameObject[,] tileArray;

    // Start is called before the first frame update
    void Start()
    {
        tileArray = new GameObject[xSize, ySize];
        CreateBoard();
    }

    private void CreateBoard()
    {
        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                int tileToUse = Random.Range(0, tile.Length);
                Vector2 temp = new Vector2(x, y);
                GameObject newTile = Instantiate(tile[tileToUse], temp, Quaternion.identity);
                newTile.transform.parent = transform;
                newTile.GetComponent<Tile>().column = x;
                newTile.GetComponent<Tile>().row = y;
                tileArray[x, y] = newTile;
            }
        }
    }
}
