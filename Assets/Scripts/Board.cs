using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private Tile[] tile;

    public int xSize, ySize;
    public bool isMatch = false;
    public Tile[,] tileArray;
        
    private List<Tile> downTile = new List<Tile>();

    private void FixedUpdate()
    {
        
        for (int i = 0; i < xSize; i++)
        {
            for (int j = 0; j < ySize; j++)
            {
                if (tileArray[i, j] == null)
                {
                    isMatch = true;
                    StartCoroutine(CreateTile(0.5f));
                    isMatch = false;
                }
            }
        }
        //StartCoroutine(CreateTile(0.5f));
    }

    void Start()
    {
        tileArray = new Tile[xSize, ySize];
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
                Tile newTile = Instantiate(tile[tileToUse], temp, Quaternion.identity);
                newTile.transform.parent = transform;
                newTile.GetComponent<Tile>().column = x;
                newTile.GetComponent<Tile>().row = y;
                tileArray[x, y] = newTile;
            }
        }
    }

    //private IEnumerator CreateTile(float value)
    //{
    //    yield return new WaitForSeconds(value);
    //    FindMatchTile();
    //}

    private IEnumerator CreateTile(float value)
    {
        while (true)
        {
            for (int y = 0; y < ySize; y++)
            {
                for (int x = 0; x < xSize; x++)
                {
                    if (y > 0 && y < ySize && tileArray[x, y] != null && tileArray[x, y - 1] == null)
                    {
                        downTile.Add(tileArray[x, y]);
                    }
                    if (y == ySize - 1 && tileArray[x, y] == null)
                    {
                        int tileToUse = Random.Range(0, tile.Length);
                        Vector2 temp = new Vector2(x, y);
                        Tile newTile = Instantiate(tile[tileToUse], temp, Quaternion.identity);
                        newTile.transform.parent = transform;
                        newTile.column = x;
                        newTile.row = y;
                        tileArray[x, y] = newTile;
                    }
                }

                foreach (var item in downTile)
                {
                    for (int xX = 0; xX < xSize; xX++)
                    {
                        if (item == tileArray[xX, y])
                        {
                            tileArray[xX, y].transform.position = new Vector2(xX, y - 1);
                            tileArray[xX, y].row = y - 1;
                            tileArray[xX, y - 1] = tileArray[xX, y];
                            tileArray[xX, y] = null;
                        }
                    }
                }
                downTile.Clear();
                yield return new WaitForSeconds(value);
            }
            break;
        }
    }
}

//    public void FindMatchTile()
//    {
//        while (true)
//        {
//            for (int y = 0; y < ySize; y++)
//            {
//                for (int x = 0; x < xSize; x++)
//                {
//                    if (y > 0 && y < ySize && tileArray[x, y] != null && tileArray[x, y - 1] == null)
//                    {
//                        isMatch = true;
//                        downTile.Add(tileArray[x, y]);
//                    }

//                    //if (y > 0 && y < ySize && tileArray[x, y] != null && tileArray[x, y - 1] == null)
//                    //{
//                    //    isMatch = true;
//                    //tileArray[x, y].transform.position = new Vector2(x, y - 1);
//                    //tileArray[x, y].row = y - 1;
//                    //tileArray[x, y - 1] = tileArray[x, y];
//                    //tileArray[x, y] = null;
//                    //FindMatchTile();
//                    //}
//                    if (y == ySize - 1 && tileArray[x, y] == null)
//                    {
//                        isMatch = true;
//                        int tileToUse = Random.Range(0, tile.Length);
//                        Vector2 temp = new Vector2(x, y);
//                        Tile newTile = Instantiate(tile[tileToUse], temp, Quaternion.identity);
//                        newTile.transform.parent = transform;
//                        newTile.column = x;
//                        newTile.row = y;
//                        tileArray[x, y] = newTile;
//                    }
//                }

//                foreach (var item in downTile)
//                {
//                    for (int xX = 0; xX < xSize; xX++)
//                    {
//                        if (item == tileArray[xX, y])
//                        {
//                            tileArray[xX, y].transform.position = new Vector2(xX, y - 1);
//                            tileArray[xX, y].row = y - 1;
//                            tileArray[xX, y - 1] = tileArray[xX, y];
//                            tileArray[xX, y] = null;
//                        }                        
//                    }
//                }
//                downTile.Clear();
//            }
//            if (!isMatch)
//            {
//                break;
//            }
//            else
//            {
//                isMatch = false;
//            }
//        }
//    }
//}
