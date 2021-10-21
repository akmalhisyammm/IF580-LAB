using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public Transform hoursTransform, minutesTransform, secondsTransform;
    public enum Mode { Clock, Stopwatch };
    public Mode mode = Mode.Clock;
    public bool continuous = false;
    public bool stopwatchActive = false;

    [SerializeField] private Text modeText;

    float stopwatchTimer = 0.0f;
    float stopwatchCurrentTime = 0.0f;
    float stopwatchHour = 0.0f;
    float stopwatchMinute = 0.0f;
    float stopwatchSecond = 0.0f;

    const float degreesPerHour = 30.0f;
    const float degreesPerMinute = 6.0f;
    const float degreesPerSecond = 6.0f;

    void Awake()
    {
        CheckUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        CheckUpdate();
        ChangeModeText();
    }

    void CheckUpdate()
    {
        if (continuous)
        {
            UpdateContinuous();
        } 
        else 
            UpdateDiscrete();
    }

    void UpdateContinuous()
    {
        if (stopwatchActive)
        {
            stopwatchTimer += Time.deltaTime;
        }

        switch (mode)
        {
            case Mode.Clock:
                TimeSpan time = DateTime.Now.TimeOfDay;

                hoursTransform.localRotation = Quaternion.Euler(0f, (float)time.TotalHours * degreesPerHour, 0f);
                minutesTransform.localRotation = Quaternion.Euler(0f, (float)time.TotalMinutes * degreesPerMinute, 0f);
                secondsTransform.localRotation = Quaternion.Euler(0f, (float)time.TotalSeconds * degreesPerSecond, 0f);
                break;
            case Mode.Stopwatch:
                if (stopwatchCurrentTime == 0.0f)
                {
                    resetStopwatchArms();
                }
                else
                {
                    currentStopwatchArms();
                }

                stopwatchHour = stopwatchTimer / 3600;
                stopwatchMinute = stopwatchTimer / 60 % 60;
                stopwatchSecond = stopwatchTimer % 60;

                hoursTransform.localRotation = Quaternion.Euler(0.0f, stopwatchHour * degreesPerHour, 0.0f);
                minutesTransform.localRotation = Quaternion.Euler(0.0f, stopwatchMinute * degreesPerMinute, 0.0f);
                secondsTransform.localRotation = Quaternion.Euler(0.0f, stopwatchSecond * degreesPerSecond, 0.0f);
                break;
        }
    }

    void UpdateDiscrete()
    {
        if (stopwatchActive)
        {
            stopwatchTimer += Time.deltaTime;
        }

        switch (mode)
        {
            case Mode.Clock:
                DateTime time = DateTime.Now;

                hoursTransform.localRotation = Quaternion.Euler(0f, time.Hour * degreesPerHour, 0f);
                minutesTransform.localRotation = Quaternion.Euler(0f, time.Minute * degreesPerMinute, 0f);
                secondsTransform.localRotation = Quaternion.Euler(0f, time.Second * degreesPerSecond, 0f);
                break;
            case Mode.Stopwatch:
                if (stopwatchCurrentTime == 0.0f)
                {
                    resetStopwatchArms();
                }
                else
                {
                    currentStopwatchArms();
                }

                stopwatchHour = (int)(stopwatchTimer / 3600);
                stopwatchMinute = (int)((stopwatchTimer / 60) % 60);
                stopwatchSecond = (int)(stopwatchTimer % 60);

                hoursTransform.localRotation = Quaternion.Euler(0.0f, stopwatchHour * degreesPerHour, 0.0f);
                minutesTransform.localRotation = Quaternion.Euler(0.0f, stopwatchMinute * degreesPerMinute, 0.0f);
                secondsTransform.localRotation = Quaternion.Euler(0.0f, stopwatchSecond * degreesPerSecond, 0.0f);
                break;
        }
    }

    void ChangeModeText()
    {
        switch (mode)
        {
            case Mode.Clock:
                modeText.text = "Mode: Clock";
                break;
            case Mode.Stopwatch:
                modeText.text = "Mode: Stopwatch";
                break;
        }
    }

    void currentStopwatchArms()
    {
        switch (continuous)
        {
            case true:
                stopwatchHour = stopwatchTimer / 3600;
                stopwatchMinute = stopwatchTimer / 60 % 60;
                stopwatchSecond = stopwatchTimer % 60;

                hoursTransform.localRotation = Quaternion.Euler(0.0f, stopwatchHour * degreesPerHour, 0.0f);
                minutesTransform.localRotation = Quaternion.Euler(0.0f, stopwatchMinute * degreesPerMinute, 0.0f);
                secondsTransform.localRotation = Quaternion.Euler(0.0f, stopwatchSecond * degreesPerSecond, 0.0f);
                break;
            case false:
                stopwatchHour = (int)(stopwatchTimer / 3600);
                stopwatchMinute = (int)((stopwatchTimer / 60) % 60);
                stopwatchSecond = (int)(stopwatchTimer % 60);

                hoursTransform.localRotation = Quaternion.Euler(0.0f, stopwatchHour * degreesPerHour, 0.0f);
                minutesTransform.localRotation = Quaternion.Euler(0.0f, stopwatchMinute * degreesPerMinute, 0.0f);
                secondsTransform.localRotation = Quaternion.Euler(0.0f, stopwatchSecond * degreesPerSecond, 0.0f);
                break;
        }
    }

    void resetStopwatchArms()
    {
        hoursTransform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        minutesTransform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        secondsTransform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
    }

    public void StartStopwatch()
    {
        stopwatchActive = true;
        stopwatchTimer = stopwatchCurrentTime;
    }

    public void StopStopwatch()
    {
        stopwatchActive = false;
        stopwatchCurrentTime = stopwatchTimer;
    }

    public void ResetStopwatch()
    {
        stopwatchActive = false;
        stopwatchTimer = stopwatchCurrentTime = 0.0f;
    }

    public void SetMode(Mode selectedMode)
    {
        mode = selectedMode;
    }
}
