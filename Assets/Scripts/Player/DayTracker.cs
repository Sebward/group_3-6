using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTracker : MonoBehaviour
{
    private int day;

    public int Day
    {
        get { return day; }
        //set { day = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        day = 1;
    }

    public void NewDay()
    {
        day++;
    }
}
