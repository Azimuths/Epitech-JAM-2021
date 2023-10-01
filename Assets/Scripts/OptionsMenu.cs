using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;

    public Dropdown resolutionDropdown;

    public Toggle fullScreenToggle;

    public Slider audioSlider;

    public GameObject banana;

    public Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> resolutionStrings = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string resolutionString = resolutions[i].width + "x" + resolutions[i].height;
            resolutionStrings.Add(resolutionString);

            if (resolutions[i].width == Screen.width
                && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        audioMixer.GetFloat("volume", out float volume);

        volume += 80;
        audioSlider.value = volume;
        banana.transform.position = new Vector2(100, 100 - volume * 10);

        fullScreenToggle.isOn = Screen.fullScreen;

        resolutionDropdown.AddOptions(resolutionStrings);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume - 80);
        banana.transform.position = new Vector2(100, 100 - volume * 10);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Debug.Log(isFullScreen);
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
