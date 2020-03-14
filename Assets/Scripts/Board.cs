using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Board : MonoBehaviour
{
    [SerializeField] private Tile[] tile;
    public ParticleSystem Particle;

    public int xSize, ySize;
    public bool isMatch = false;
    public Tile[,] tileArray;
    public GameObject PopupMenu;
    public bool isPopupMenu = false;
    public float TimeTileReduction = 0.05f;


    private List<Tile> downTile = new List<Tile>();

    private void FixedUpdate()
    {
        CreateTile();
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
                newTile.GetComponent<Tile>().Column = x;
                newTile.GetComponent<Tile>().Row = y;
                tileArray[x, y] = newTile;
            }
        }
    }

    private void CreateTile()
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
                    newTile.Column = x;
                    newTile.Row = y;
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
                        tileArray[xX, y].Row = y - 1;
                        tileArray[xX, y - 1] = tileArray[xX, y];
                        tileArray[xX, y] = null;
                    }
                }
            }
            downTile.Clear();
        }
    }
}

//private IEnumerator CreateTile(float value)
//{
//    yield return new WaitForSeconds(value);
//    FindMatchTile();
//}

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
