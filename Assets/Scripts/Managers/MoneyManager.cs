using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    
	public int MoneyValue = 15;
    public int Power = 5;
    public int DelayAmount = 1; // Second count
    public Text MoneyValueText;

    protected float Timer;

    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer >= DelayAmount)
        {
            Timer = 0f;
            MoneyValue++; // For every DelayAmount or "second" it will add one to the GoldValue
            MoneyValueText.text = "Money value: " + MoneyValue;
        }
    }
}


