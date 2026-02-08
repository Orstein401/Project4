using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UiCoin : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textCoin;
    [SerializeField] private int maxCoin;
    [SerializeField] private UnityEvent eventsUi;
    private int currentCoin;

    public void AddCoinToCounter(int numCoin)
    {
        currentCoin += numCoin;
        textCoin.SetText($"{currentCoin}/{maxCoin}");
        CheckCoin();
    }

    private void CheckCoin()
    {
        if (currentCoin >= maxCoin)
        {
            eventsUi.Invoke();
        }
    }
}
