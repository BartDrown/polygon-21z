using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class TimerScript : MonoBehaviour
{
    [SerializeField] TMP_Text timer;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<GameManager>().gameHasEnded != true)
        {
            float t = Time.time - startTime;
            float seconds = Mathf.Floor(t);
            timer.text = "You survived for: " + seconds.ToString() + " seconds!";
        }
    }
}
