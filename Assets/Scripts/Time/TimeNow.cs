using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeNow : MonoBehaviour
{

    Text ClockText;

    // Use this for initialization
    void Start()
    {
        ClockText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        string hour = DateTime.Now.Hour.ToString();
        int nowHour = int.Parse(hour);
        //0埋めを行う
        if (nowHour < 10)
        {
            ClockText.text = "0" + DateTime.Now.ToShortTimeString();
        }
        else
        {
            ClockText.text = DateTime.Now.ToShortTimeString();
        }
    }
}
