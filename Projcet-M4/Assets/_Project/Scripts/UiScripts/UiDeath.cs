using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class UiDeath : MonoBehaviour
{
    [SerializeField] private Canvas interFacePlayer;
    [SerializeField] private Canvas uiDeath;

    public void StartDeathUi()
    {
        interFacePlayer.enabled = false;
        uiDeath.enabled = true;
    }
    public void Restarlevel()
    {
        SceneManager.LoadScene(1);
    }
    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
    }

}
