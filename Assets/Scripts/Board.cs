using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject[] tile;
    public int xSize, ySize;
    public GameObject[,] tileArray;
    public bool isMatch = false;
    private float time = 0.5f;

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && !isMatch)
        {
            for (int i = 0; i < xSize; i++)
            {
                for (int j = 0; j < ySize; j++)
                {
                    if (tileArray[i,j] == null)
                    {
                        StartCoroutine(CreateTile(1.0f));
                    }
                }
            }            
        }
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

    private IEnumerator CreateTile(float value)
    {
        isMatch = true;
        yield return new WaitForSeconds(value);
        FindMatchTile();
    }

    public void FindMatchTile()
    {
        while (isMatch)
        {
            for (int x = 0; x < xSize; x++)
            {
                for (int y = 0; y < ySize; y++)
                {
                    if (y > 0 && y < ySize && tileArray[x, y] != null && tileArray[x, y - 1] == null)
                    {
                        isMatch = true;
                        tileArray[x, y].transform.position = new Vector2(x, y - 1);
                        tileArray[x, y].GetComponent<Tile>().row = y - 1;
                        tileArray[x, y - 1] = tileArray[x, y];
                        tileArray[x, y] = null;
                        FindMatchTile();
                    }
                    else if (y == ySize - 1 && tileArray[x, y] == null)
                    {
                        isMatch = true;
                        int tileToUse = Random.Range(0, tile.Length);
                        Vector2 temp = new Vector2(x, y);
                        GameObject newTile = Instantiate(tile[tileToUse], temp, Quaternion.identity);
                        newTile.transform.parent = transform;
                        newTile.GetComponent<Tile>().column = x;
                        newTile.GetComponent<Tile>().row = y;
                        tileArray[x, y] = newTile;
                        FindMatchTile();
                    }
                }
            }
            isMatch = false;
        }
               
    }

    //public void FindMatchTile()
    //{
    //    for (int x = 0; x < xSize; x++)
    //    {
    //        for (int y = 0; y < ySize; y++)
    //        {
    //            if (y > 0 && y < ySize && tileArray[x, y] != null && tileArray[x, y - 1] == null)
    //            {
    //                isMatch = true;
    //                tileArray[x, y].transform.position = new Vector2(x, y - 1);
    //                tileArray[x, y].GetComponent<Tile>().row = y - 1;
    //                tileArray[x, y - 1] = tileArray[x, y];
    //                tileArray[x, y] = null;
    //            }
    //            else if (y == ySize - 1 && tileArray[x, y] == null)
    //            {
    //                isMatch = true;
    //                int tileToUse = Random.Range(0, tile.Length);
    //                Vector2 temp = new Vector2(x, y);
    //                GameObject newTile = Instantiate(tile[tileToUse], temp, Quaternion.identity);
    //                newTile.transform.parent = transform;
    //                newTile.GetComponent<Tile>().column = x;
    //                newTile.GetComponent<Tile>().row = y;
    //                tileArray[x, y] = newTile;
    //            }
    //        }
    //    }
    //}
}
