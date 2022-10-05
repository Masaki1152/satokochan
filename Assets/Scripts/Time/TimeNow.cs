using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeNow : MonoBehaviour
{

    private Text ClockText;

    // Use this for initialization
    void Start()
    {
        ClockText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        var hour = DateTime.Now.Hour;
        if (hour < 10)
        {
            ClockText.text = "0" + DateTime.Now.ToLongTimeString();
        }
        else
        {
            ClockText.text = DateTime.Now.ToLongTimeString();
        }
    }
}
