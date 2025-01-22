using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public string volumeParametr = "MusicVol";
    public string volumeParametr2 = "GunShots";
    public AudioMixer mixer;
    public Slider slider;

    private const float _multiplier = 20f;
    private float volumeValue;

    private void Awake()
    {
        slider.onValueChanged.AddListener(HandleSlideValueChanged);
    }
    private void Start()
    {
        slider.value = Mathf.Pow(10f, volumeValue / _multiplier);
    }
    private void HandleSlideValueChanged(float value)
    {
        var volumeValue = Mathf.Log10(value) * _multiplier;
        mixer.SetFloat(volumeParametr, volumeValue);
        mixer.SetFloat(volumeParametr2, volumeValue);
    }

}

