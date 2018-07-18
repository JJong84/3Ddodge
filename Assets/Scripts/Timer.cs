using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Text timeLabel;
    public string score;
    public float timeCount;

    // Use this for initialization
    void Start()
    {
        timeCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        score = string.Format("{0:N3}", timeCount);
        timeLabel.text = "Time: " + score;
    }
}
