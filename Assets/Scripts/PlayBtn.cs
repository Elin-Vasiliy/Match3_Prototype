using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayBtn : MonoBehaviour
{
    public Sprite playUp;
    public Sprite playDown;
    public Image play;

    public void Play()
    {
        play.sprite = playDown;
        SceneManager.LoadScene(1);
    }

    //public void OnMouseDown()
    //{
    //    play.sprite = playDown;
    //}

    //public void OnMouseUp()
    //{
    //    play.sprite = playUp;
    //}
}
