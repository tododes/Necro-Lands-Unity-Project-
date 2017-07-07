using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;

[System.Serializable]
public class Chrono {

    public int Year;
    public int Month;
    public int Week;
    public int Day;
    public int Hour;
    public int Minute;
    public int Second;

    public Chrono(int year = 0, int month = 0, int day = 0, int hour = 0, int minute = 0, int second = 0){
        Year = year;
        Month = month;
        Day = day;
        Hour = hour;
        Minute = minute;
        Second = second;
    }

    public Chrono(DateTime dateTime){
        Year = dateTime.Year;
        Month = dateTime.Month;
        Day = dateTime.Day;
        Hour = dateTime.Hour;
        Minute = dateTime.Minute;
        Second = dateTime.Second;
    }

    public override string ToString(){
        StringBuilder sb = new StringBuilder();
        sb.Append(Month);
        sb.Append("/");
        sb.Append(Day);
        sb.Append("/");
        sb.Append(Year);
        sb.Append(" ");
        sb.Append(Hour);
        sb.Append(":");
        sb.Append(Minute);
        sb.Append(":");
        sb.Append(Second);
        return sb.ToString();
    }

    public DateTime ToDateTime(){
        return new DateTime(Year, Month, Day, Hour, Minute, Second);
    }
}
