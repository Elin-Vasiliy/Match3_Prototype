using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTile : MonoBehaviour
{
    public delegate void DeleteTileDelegat();
    event DeleteTileDelegat TileDelete;

    DeleteTileDelegat del;

    private void Awake()
    {        
        del += Delete;
    }

    public void Delete()
    {
        gameObject.SetActive(false);
    }
}
