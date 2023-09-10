using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{
    public static Action onMinutechanged;
    public static Action onHourchanged;
    public static Action onDaychanged;
    public static Action onMonthchanged;
    public static Action onYearschanged;


    public static int minute { get; private set; }
    public static int hour { get; private set; }

    public static int day { get; private set; }
    public static int month { get; private set; }
    public static int year { get; private set; }

    private float TimeConvertRate = 1f;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        hour = 0;  minute = 0; day = 1; month = 1; year = 2020;
        timer = TimeConvertRate;

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;


        if (timer <= 0)
        {
            // change times
            minute += 5;
            onMinutechanged?.Invoke();
            if (minute >= 60)
            {
                
                minute = 0;
                hour++;
                onHourchanged?.Invoke();
            }

            // change days
            if (hour >= 24)
            {
                day++; hour = 0;
            }

            // change month
            if (month == 4 | month == 6 | month == 9 | month == 11)
            {
                if (day > 31)
                {
                    day = 1;
                    month++;
                    onMonthchanged?.Invoke();
                }
            }
            else if (month == 2)
            {
                if (DateTime.IsLeapYear(year))
                {
                    if (day > 29)
                    {
                        day = 1;
                        month++;
                        onMonthchanged?.Invoke();
                    }
                }
                else
                {
                    if (day > 28)
                    {
                        day = 1;
                        month++;
                        onMonthchanged?.Invoke();
                    }
                }
            }
            else
            {
                if (day > 30)
                {
                    day = 1;
                    month++;
                    onMonthchanged?.Invoke();
                }
            }

            //change years
            if(month > 12)
            {
                month = 1;
                year++;
                onYearschanged?.Invoke();
            }

            timer = TimeConvertRate;
        }
    }


}
