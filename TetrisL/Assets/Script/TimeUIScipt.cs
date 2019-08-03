using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUIScipt : MonoBehaviour
{
    private Text time;

    private float timeScroe, startTime;

    // Start is called before the first frame update
    void Start()
    {
        time = GetComponent<Text>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        timeScroe = Time.time - startTime;
        int minute = (int)timeScroe / 60;
        int second = (int)timeScroe % 60;
        time.text = (string)string.Format("{0:00}:{1:00}", minute, second);
    }
}
