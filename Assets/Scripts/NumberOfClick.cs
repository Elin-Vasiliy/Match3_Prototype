using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberOfClick : MonoBehaviour
{
    public static int numsClick = 0;

    private void Update()
    {
        //if (Input.GetMouseButton(0))
        //{
        //    Debug.Log(numsClick);
        //}        
    }

    public void ClickToMouse()
    {
        Debug.Log(numsClick);
    }
}
