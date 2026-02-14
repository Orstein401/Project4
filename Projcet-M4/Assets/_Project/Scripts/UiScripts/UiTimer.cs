
using TMPro;
using UnityEngine;

public class UiTimer : MonoBehaviour
{
    [Header("Time")]
    [SerializeField] private int minutes;
    [SerializeField] private float seconds;
    private bool isOver = false;

    [Header("Ui")]
    [SerializeField] private TextMeshProUGUI textTimer;

    [Header("Componets")]
    private UiEvents gameOver;

    private void Awake()
    {
        gameOver = GetComponent<UiEvents>();
    }
    private void Update()
    {

        if (!isOver) Timer();
    }

    private void Timer()
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
