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
        AudioManager.instance.PlaySFX(Clip.ClickBtn);
        isMenu = true;
        PopupMenu.SetActive(true);        
    }

    public void ClosePopupMenu()
    {
        AudioManager.instance.PlaySFX(Clip.ClickBtn);
        PopupMenu.SetActive(false);
        isMenu = false;
    }

    public void ExitMenu()
    {
        AudioManager.instance.PlaySFX(Clip.ClickBtn);
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        AudioManager.instance.PlaySFX(Clip.ClickBtn);
        PopupExitDialogue.SetActive(true);
    }

    public void BtnYesExit()
    {
        AudioManager.instance.PlaySFX(Clip.ClickBtn);
        Application.Quit();
#if UNITY_STANDALONE
			// Quit the application
			Application.Quit();
#endif

        // If we are running in the editor
#if UNITY_EDITOR
        // Stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void BtnNoExit()
    {
        AudioManager.instance.PlaySFX(Clip.ClickBtn);
        PopupExitDialogue.SetActive(false);
    }

    public void Restart()
    {
        AudioManager.instance.PlaySFX(Clip.ClickBtn);
        Invoke("RestartLoadScene", 0.5f);
    }

    public void RestartLoadScene()
    {
        SceneManager.LoadScene(1);
    }
}
