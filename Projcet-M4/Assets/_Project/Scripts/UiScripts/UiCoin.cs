using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiCoin : MonoBehaviour
{
    [SerializeField] private TMP_Text textCoin;
    [SerializeField] private int maxCoin;
    private int currentCoin;
    public void AddCoinToCounter(int numCoin)
    {
        textCoin.SetText($"{currentCoin+numCoin}/{maxCoin}");
    }
}
