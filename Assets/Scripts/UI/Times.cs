using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class Times : MonoBehaviour
{
    public TextMeshProUGUI TimeText;

    private string[] MonthText = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };


    private void OnEnable()
    {
        TimeManager.onMinutechanged += UpdateTime;
        TimeManager.onHourchanged += UpdateTime;
        TimeManager.onDaychanged += UpdateTime;
        TimeManager.onMonthchanged += UpdateTime;
        TimeManager.onYearschanged += UpdateTime;
    }

    private void OnDisable()
    {
        TimeManager.onMinutechanged -= UpdateTime;
        TimeManager.onHourchanged -= UpdateTime;
        TimeManager.onDaychanged -= UpdateTime;
        TimeManager.onMonthchanged -= UpdateTime;
        TimeManager.onYearschanged -= UpdateTime;
    }

    private void UpdateTime()
    {
        TimeText.text = $"{TimeManager.hour:00} : {TimeManager.minute:00}       {TimeManager.day:00} {MonthText[TimeManager.month - 1]} {TimeManager.year:0000}";
    }

}
