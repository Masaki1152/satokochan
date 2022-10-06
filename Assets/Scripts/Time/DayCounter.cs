using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DayCounter : MonoBehaviour
{
    DateTime startDay;
    DateTime Today;
    int dayCount;
    Text day;

    // Start is called before the first frame update
    void Start()
    {
        startDay = DateTime.Now;
        PlayerPrefs.SetString("StartDay", startDay.ToBinary().ToString());
        PlayerPrefs.Save();
        day = GameObject.FindGameObjectWithTag("Day").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Today = DateTime.Now;

        //?J?n????????
        string datetimeString = PlayerPrefs.GetString("StartDay");
        startDay = System.DateTime.FromBinary(System.Convert.ToInt64(datetimeString));

        dayCount = (Today - startDay).Days;
        day.text = dayCount + 1 + "日目";
    }
}
