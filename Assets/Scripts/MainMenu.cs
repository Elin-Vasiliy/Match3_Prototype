using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject PopupExitDialogue;

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
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
}
