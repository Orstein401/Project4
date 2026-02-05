using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiEvents : MonoBehaviour
{
    [SerializeField] private Canvas interFacePlayer;
    [SerializeField] private Canvas uiDeath;
    [SerializeField] private Canvas uiWin;

    private int indexScene;

    public void StartDeathUi()
    {
        Time.timeScale = 0;
        interFacePlayer.enabled = false;
        uiDeath.enabled = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void StartWinUi()
    {
        Time.timeScale = 0;
        interFacePlayer.enabled = false;
        uiWin.enabled = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void NextLevel()
    {
        Time.timeScale = 1;
        indexScene = SceneManager.GetActiveScene().buildIndex+1;
        SceneManager.LoadScene(indexScene);
    }
    public void RestartLevel()
    {
        Time.timeScale = 1;
        indexScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(indexScene);
    }
    public void ReturnMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

}
