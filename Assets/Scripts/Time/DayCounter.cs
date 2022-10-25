using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DayCounter : MonoBehaviour
{
    string dayCheck = "true";   //開始日の取得を最初だけ行うための確認
    DateTime startDay;
    DateTime Today;
    double dayCount;
    Text day;
    DateTime dateFrom;
    DateTime dateTo;

    // Start is called before the first frame update
    void Start()
    {
        //trueなら1回目のため開始日を取得して保存
        if (dayCheck == "true")
        {
            startDay = DateTime.Now;
            string y = startDay.Year.ToString();
            string m = startDay.Month.ToString();
            string d = startDay.Day.ToString();
            PlayerPrefs.SetString("StartDay", y + "," + m + "," + d);
            PlayerPrefs.Save();
            Debug.Log("初めの日は" + PlayerPrefs.GetString("StartDay"));
            dayCheck = "false";  //2回目以降は開始日の取得を行わない
        }
        else
        {
            Debug.Log("初めの日は" + PlayerPrefs.GetString("StartDay"));
        }
        day = GameObject.FindGameObjectWithTag("Day").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Today = DateTime.Now;

        //開始日の取得
        string datetimeString = PlayerPrefs.GetString("StartDay");
        string[] ymd = datetimeString.Split(',');
        dateFrom = new System.DateTime(int.Parse(ymd[0]), int.Parse(ymd[1]), int.Parse(ymd[2]));

        //本日の取得
        string y = Today.Year.ToString();
        string m = Today.Month.ToString();
        string d = Today.Day.ToString();
        dateTo = new System.DateTime(int.Parse(y), int.Parse(m), int.Parse(d));

        //ログイン日数を計算
        dayCount = (dateTo - dateFrom).TotalDays;
        day.text = dayCount + 1 + "日目";
    }
}
