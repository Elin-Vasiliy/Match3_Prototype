using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject[] tile;
    public int xSize, ySize;
    public GameObject[,] tileArray;
    public bool isMatch = false;

    private void Update()
    {
        //if (isMatch)
        //{
        //    StartCoroutine(CreateTile());
        //}
        FindMatchTile();
    }

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

    //private IEnumerator CreateTile()
    //{

    //    FindMatchTile();
    //    yield return new WaitForSeconds(0.5f);
    //    isMatch = false;
    //}

    public void FindMatchTile()
    {
        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                if (y < ySize - 1 && y > 0)
                {
                    if (tileArray[x, y + 1] != null && tileArray[x, y] == null)
                    {
                        Vector2 temp = new Vector2(x, y);
                        GameObject newTile = Instantiate(tileArray[x, y + 1], temp, Quaternion.identity);
                        newTile.transform.parent = transform;
                        newTile.name = tileArray[x, y + 1].name;
                        newTile.GetComponent<Tile>().column = x;
                        newTile.GetComponent<Tile>().row = y;
                        tileArray[x, y] = newTile;
                        Destroy(tileArray[x, y + 1]);
                    }
                }
                else if (y == 0 || y == ySize - 1)
                {
                    if (y == 0)
                    {
                        if (tileArray[x, y + 1] != null && tileArray[x, y] == null)
                        {
                            Vector2 temp = new Vector2(x, y);
                            GameObject newTile = Instantiate(tileArray[x, y + 1], temp, Quaternion.identity);
                            newTile.transform.parent = transform;
                            newTile.name = tileArray[x, y + 1].name;
                            newTile.GetComponent<Tile>().column = x;
                            newTile.GetComponent<Tile>().row = y;
                            tileArray[x, y] = newTile;
                            Destroy(tileArray[x, y + 1]);
                        }
                    }
                    if (y == ySize - 1 && tileArray[x, y] == null)
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
    }
}
