using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer m_audioMixer;
    public Dropdown m_resolutionDropdown;

    public Slider m_musicSlider;
    public Slider m_sfxSlider;

    Resolution[] m_resolutions;

    public void Start()
    {
        m_audioMixer.GetFloat("VolumeMusic", out float musicValueForSLider);
        m_musicSlider.value = musicValueForSLider;
        m_audioMixer.GetFloat("VolumeSFX", out float sfxValueForSLider);
        m_sfxSlider.value = sfxValueForSLider;


        m_resolutions = Screen.resolutions.Select(Resolution => new Resolution { width = Resolution.width, height = Resolution.height }).Distinct().ToArray();
        m_resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < m_resolutions.Length; i++)
        {
            string option = m_resolutions[i].width + " x " + m_resolutions[i].height;
            options.Add(option);

            if (m_resolutions[i].width == Screen.width && m_resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        m_resolutionDropdown.AddOptions(options);
        m_resolutionDropdown.value = currentResolutionIndex;
        m_resolutionDropdown.RefreshShownValue();

        Screen.fullScreen = true;
    }

    public void SetVolumeMusic(float volume)
    {
        m_audioMixer.SetFloat("VolumeMusic", volume);
    }

    public void SetVolumeSFX(float volume)
    {
        m_audioMixer.SetFloat("VolumeSFX", volume);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = m_resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
