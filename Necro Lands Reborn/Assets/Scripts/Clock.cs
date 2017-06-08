using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Clock
{
    [SerializeField] private int Minute;
    [SerializeField] private int Second;

    public Clock(int minute = 0, int second = 0)
    {
        Minute = minute;
        Second = second;
    }

    public int min
    {
        get { return Minute; }
        private set { Minute = value; }
    }

    public int sec
    {
        get { return Second; }
        private set { Second = value; }
    }

    public void Tick()
    {

        if (Minute > 0)
        {
            Second--;
            if (Second < 0)
            {
                Minute -= 1;
                Second = 59;
            }
        }
    }

    public int CompareToClock(Clock obj) {
        if (Minute == obj.min && Second == obj.sec)
            return 0;
        if (Minute > obj.min || Second > obj.sec)
            return 1;
        else
            return -1;
    }
}

