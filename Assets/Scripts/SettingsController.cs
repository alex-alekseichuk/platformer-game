using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SettingsController : MonoBehaviour
{
    void Start()
    {
        this.tglFullScreen.isOn = PlayerPrefs.GetInt("isFullScreen", 0) == 1;
        this.ddlResolution.value = PlayerPrefs.GetInt("resolution", 0);
        this.sliderMusic.value = PlayerPrefs.GetFloat("music", 0);
        this.sliderSounds.value = PlayerPrefs.GetFloat("sounds", 0);
    }

    void Update()
    {
        
    }

    public void Cancel() {
        SceneManager.LoadScene("MenuScene");
    }

    public void Save() {
        PlayerPrefs.SetInt("isFullScreen", this.tglFullScreen.isOn ? 1 : 0);
        PlayerPrefs.SetInt("resolution", this.ddlResolution.value);
        PlayerPrefs.SetFloat("music", this.sliderMusic.value);
        PlayerPrefs.SetFloat("sounds", this.sliderSounds.value);
        PlayerPrefs.Save();
        SceneManager.LoadScene("MenuScene");
    }

    [SerializeField] private TMP_Dropdown ddlResolution;
    [SerializeField] private Toggle tglFullScreen;
    [SerializeField] private Slider sliderMusic;
    [SerializeField] private Slider sliderSounds;
}
