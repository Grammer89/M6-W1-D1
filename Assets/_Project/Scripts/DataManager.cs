using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    [Header("Slider/Toggle")]
    [SerializeField] private Slider _sliderVfx;
    [SerializeField] private Slider _sliderQualityVideo;
    [SerializeField] private Toggle _toggleGodMode;

    private float _sliderVfxValue;
    private float _sliderQualityVideoValue;
    private string _toggleGodModeValue;

    public float SliderVfx { get { return _sliderVfxValue; } set { _sliderVfxValue = value; } }
    public float SliderQualityVideo { get { return _sliderQualityVideoValue; } set { _sliderQualityVideoValue = value; } }
    public string ToogleGodMode { get { return _toggleGodModeValue; } set { _toggleGodModeValue = value; } }

    public const string _KeySliderVfx = "Vfx";
    public const string _KeyQualityVideo = "Video";
    public const string _KeyGodMode = "God";

    public void SaveVFX(float value)
    { _sliderVfxValue = value; }

    public void SaveQualityVideo(float value)
    { _sliderQualityVideoValue = value; }

    public void SaveGodMode(bool value)
    {
        if (value)
        {
            _toggleGodModeValue = "X";
        }
        else
        {
            _toggleGodModeValue = null;
        }

        Debug.Log("Checkbox value: " + _toggleGodModeValue);
    }

    private void Awake()
    {
        _sliderVfxValue = _sliderVfx.value;
        _sliderQualityVideoValue = _sliderQualityVideo.value;
        if (_toggleGodMode.isOn)
        {
            _toggleGodModeValue = "X";
        }
        else
        {
            _toggleGodModeValue = null;
        }

    }
    public void SaveSystem()
    {
        PlayerPrefs.SetFloat(_KeySliderVfx, _sliderVfxValue);
        PlayerPrefs.SetFloat(_KeyQualityVideo, _sliderQualityVideoValue);
        PlayerPrefs.SetString(_KeyGodMode, _toggleGodModeValue);
        Debug.Log("Checkbox value Save: " + _toggleGodModeValue);
    }

    public void LoadSystem()
    {
        _sliderVfxValue = PlayerPrefs.GetFloat(_KeySliderVfx);
        _sliderVfx.value = _sliderVfxValue;

        _sliderQualityVideoValue = PlayerPrefs.GetFloat(_KeyQualityVideo);
        _sliderQualityVideo.value = _sliderQualityVideoValue;

        _toggleGodModeValue = PlayerPrefs.GetString(_KeyGodMode);
        Debug.Log("Checkbox value Load: " + _toggleGodModeValue);
        if (_toggleGodModeValue.Equals("X"))
        { _toggleGodMode.isOn = true; }
        else
        { _toggleGodMode.isOn = false; }

    }
}
