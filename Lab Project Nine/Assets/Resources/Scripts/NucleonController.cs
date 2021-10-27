using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NucleonController : MonoBehaviour
{
    [SerializeField] private float timeScale = 1.0f;
    [SerializeField] private float[] slowMotionPresets = { 0.2f, 0.1f, 0.05f };
    [SerializeField] private float[] fastForwardPresets = { 2.0f, 5.0f, 10.0f };

    private float fixedDeltaTime;
    private Slider timeScaleSlider;
    private Dropdown slowMotionDropdown;
    private Dropdown fastForwardDropdown;

    void Awake()
    {
        slowMotionDropdown = GameObject.FindGameObjectWithTag("SlowMotionDropdown").GetComponent<Dropdown>();
        fastForwardDropdown = GameObject.FindGameObjectWithTag("FastForwardDropdown").GetComponent<Dropdown>();
        timeScaleSlider = GameObject.FindGameObjectWithTag("TimeScaleSlider").GetComponent<Slider>();
        fixedDeltaTime = Time.fixedDeltaTime;
    }

    // Start is called before the first frame update
    void Start()
    {
        InitializeSlowMotionDropdown();
        InitializeFastForwardDropdown();
        SetTimeScaleSliderValue();
    }

    // Update is called once per frame
    void Update()
    {
        SetTimeScaleSliderValue();
    }

    void SetTimeScaleSliderValue()
    {
        timeScaleSlider.value = timeScale;
    }

    private void InitializeSlowMotionDropdown()
    {
        slowMotionDropdown.ClearOptions();
        for (int i = 0; i < slowMotionPresets.Length; i++)
        {
            slowMotionDropdown.options.Add(new Dropdown.OptionData() { text = slowMotionPresets[i].ToString() });
        }

        DropdownItemSelected(slowMotionDropdown);
        slowMotionDropdown.onValueChanged.AddListener(delegate { DropdownItemSelected(slowMotionDropdown); });
    }

    private void InitializeFastForwardDropdown()
    {
        fastForwardDropdown.ClearOptions();
        for (int i = 0; i < fastForwardPresets.Length; i++)
        {
            fastForwardDropdown.options.Add(new Dropdown.OptionData() { text = fastForwardPresets[i].ToString() });
        }

        DropdownItemSelected(fastForwardDropdown);
        fastForwardDropdown.onValueChanged.AddListener(delegate { DropdownItemSelected(fastForwardDropdown); });
    }

    private void DropdownItemSelected(Dropdown dropdown)
    {
        dropdown.captionText.text = dropdown.options[dropdown.value].text;
    }

    public void ApplyPresets()
    {
        float value = 1.0f;
        string clickedButtonObjectName = EventSystem.current.currentSelectedGameObject.name;

        switch (clickedButtonObjectName)
        {
            case "SlowMotion Button":
                value = float.Parse(slowMotionDropdown.captionText.text);
                break;
            case "RealTime Button":
                value = 1.0f;
                break;
            case "FastForward Button":
                value = float.Parse(fastForwardDropdown.captionText.text);
                break;
        }

        SetTimeScale(value);
    }

    public void SetTimeScale(float value)
    {
        timeScale = value;
        Time.timeScale = timeScale;
        Time.fixedDeltaTime = Time.timeScale * fixedDeltaTime;
    }
}
