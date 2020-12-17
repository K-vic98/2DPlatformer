using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moneybox : MonoBehaviour
{
    public static int CoinCount { get; private set; }
    private Text _coinCounter;

    private void Awake()
    {
        _coinCounter = GetComponent<Text>();
        CoinCount = 0;
    }

    private void Update()
    {
        _coinCounter.text = "X" + CoinCount;
    }
}
