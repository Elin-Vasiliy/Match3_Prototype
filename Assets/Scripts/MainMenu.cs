using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject PopupExitDialogue;

    public void PlayGame()
    {
        AudioManager.instance.PlaySFX(Clip.ClickBtn);
        Invoke("PlayGameLoadScene", 0.5f);
    }

    public void PlayGameLoadScene()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        AudioManager.instance.PlaySFX(Clip.ClickBtn);
        PopupExitDialogue.SetActive(true);
    }

    public void BtnYesExit()
    {
        Application.Quit();
    }

    public void BtnNoExit()
    {
        AudioManager.instance.PlaySFX(Clip.ClickBtn);
        PopupExitDialogue.SetActive(false);
    }
}
