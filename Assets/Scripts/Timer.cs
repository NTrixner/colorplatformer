using System;
using System.Collections;
using System.Collections.Generic;
using Movement;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float totalTime;

    [SerializeField] private TextMeshProUGUI tmp;
    [SerializeField] private TextMeshProUGUI scoreLabel;
    [SerializeField] private GameObject paintBarUi;
    [SerializeField] private GameObject levelCompleteUi;

    // Update is called once per frame
    void Update()
    {
        totalTime += Time.deltaTime;
        tmp.text = FormatTime();
    }

    public string FormatTime()
    {
        int seconds = Mathf.FloorToInt(totalTime);
        int secondsOnTheClock = seconds % 60;
        int minutesOnTheClock = Mathf.FloorToInt((float) seconds / 60f);
        return string.Format("{0}:{1}", minutesOnTheClock, (secondsOnTheClock < 10 ? "0" : "") + secondsOnTheClock);
    }

    public void FinishLevel()
    {
        scoreLabel.text = FormatTime();
        paintBarUi.SetActive(false);
        transform.parent.gameObject.SetActive(false);
        ThirdPersonController player = FindObjectOfType<ThirdPersonController>();
        if(player != null)
            player.gameObject.SetActive(false);
        
        levelCompleteUi.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}