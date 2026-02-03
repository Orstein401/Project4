using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UiTimer : MonoBehaviour
{
    [Header("Time")]
    [SerializeField] private int minutes;
    [SerializeField] private float seconds;

    private bool isOver = false;

    [Header("Ui")]
    [SerializeField] private TMP_Text textTimer;

    [Header("Componets")]
    private UiDeath gameOver;

    private void Awake()
    {
        gameOver = GetComponent<UiDeath>();
    }
    private void Update()
    {

        if (!isOver) Timer();
    }

    public void Timer()
    {
        seconds -= Time.deltaTime;
        if (minutes <= 0 && seconds <= 0)
        {
            isOver = true;
            gameOver.StartDeathUi();
        }

        if (!isOver)
        {
            if (seconds <= 0)
            {
                seconds = 59f;
                minutes -= 1;
            }
        }
        

        textTimer.SetText($"{minutes}:{seconds:00}");
    }
}
