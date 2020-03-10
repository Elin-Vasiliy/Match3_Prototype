using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject PopupMenu;
    public GameObject PopupExitDialogue;
    public bool isMenu = false;

    private void Start()
    {
        PopupMenu.SetActive(false);
        PopupExitDialogue.SetActive(false);
    }

    public void OpenPopupMenu()
    {
        isMenu = true;
        PopupMenu.SetActive(true);        
    }

    public void ClosePopupMenu()
    {
        PopupMenu.SetActive(false);
        isMenu = false;
    }

    public void ExitMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        PopupExitDialogue.SetActive(true);
    }

    public void BtnYesExit()
    {
        Application.Quit();
    }

    public void BtnNoExit()
    {
        PopupExitDialogue.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
