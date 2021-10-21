using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    Clock clock;

    // Start is called before the first frame update
    void Start()
    {
        clock = GameObject.FindGameObjectWithTag("Clock").GetComponent<Clock>();
    }

    private void OnMouseDown()
    {
        switch (gameObject.name)
        {
            case "Start/Stop Button":
                Debug.Log("Start/Stop Button");
                
                switch (clock.stopwatchActive)
                {
                    case true:
                        clock.StopStopwatch();
                        break;
                    case false:
                        clock.StartStopwatch();
                        break;
                }
                break;
            case "Clock Button":
                Debug.Log("Clock Button");

                clock.SetMode(Clock.Mode.Clock);
                break;
            case "Stopwatch Button":
                Debug.Log("Stopwatch Button");

                clock.SetMode(Clock.Mode.Stopwatch);
                break;
            case "Reset Button":
                Debug.Log("Reset Button");

                clock.ResetStopwatch();
                break;
            case "Continuous Button":
                Debug.Log("Continuous Button");

                clock.continuous = true;
                break;
            case "Discrete Button":
                Debug.Log("Discrete Button");

                clock.continuous = false;
                break;
        }
    }
}
