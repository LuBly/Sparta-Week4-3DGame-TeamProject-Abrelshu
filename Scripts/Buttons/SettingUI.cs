using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    public Button AudioPanelBtn;
    public Button VideoPanelBtn;
    public Button GameplayPanelBtn;
    public Button SettingBtn;
    public Button ResetBtn;

    //public Slider BGMSlider;
    //public Slider SFXSlider;
    //public Toggle BGMMuteToggle;
    //public Toggle SFXMuteToggle;
    //public TMP_Dropdown VolumeDropdown;
    //public TMP_Dropdown BGMDropdown;

    public GameObject SettingMenu;
    public GameObject AudioMenu;
    public GameObject GameplayMenu;
    public GameObject VideoMenu;

    private void Awake()
    {
        LoadSettings();
    }
    private void Start()
    {
        AudioPanelBtn.onClick.AddListener(() =>
        {
            LoadAudioMenu();
            AudioManager.instance.PlaySoundEffect(0); // 버튼 클릭 효과음 재생
        });

        GameplayPanelBtn.onClick.AddListener(() =>
        {
            LoadGameplayMenu();
            AudioManager.instance.PlaySoundEffect(0); // 버튼 클릭 효과음 재생
        });

        ResetBtn.onClick.AddListener(() =>
        {
            ResetSettings();
            AudioManager.instance.PlaySoundEffect(0); // 버튼 클릭 효과음 재생
        });

        // 토글 및 슬라이더 값이 변경될 때마다 AudioManager에 적용
        AudioManager.instance.BGMMuteToggle.onValueChanged.AddListener((isMuted) =>
        {
            AudioManager.instance.ToggleBGM(isMuted);
        });

        AudioManager.instance.SFXMuteToggle.onValueChanged.AddListener((isMuted) =>
        {
            AudioManager.instance.ToggleSFX(isMuted);
        });

        AudioManager.instance.BGMSlider.onValueChanged.AddListener((volume) =>
        {
            AudioManager.instance.SetBackgroundMusicVolume(volume);
        });

        AudioManager.instance.SFXSlider.onValueChanged.AddListener((volume) =>
        {
            AudioManager.instance.SetSoundEffectVolume(volume);
        });

        AudioManager.instance.VolumeDropdown.onValueChanged.AddListener((index) =>
        {
            float volume = AudioManager.instance.DropdownIndexToVolume(index);
            AudioManager.instance.SetBackgroundMusicVolume(volume);
            AudioManager.instance.SetSoundEffectVolume(volume);
            AudioManager.instance.ChangeVolumeFromDropdown(index);
        });

        AudioManager.instance.BGMDropdown.onValueChanged.AddListener((index) =>
        {
            AudioManager.instance.PlayBackgroundMusic(index);
        });
    }

    // Start is called before the first frame update
    //void Start()
    //{
    //    AudioPanelBtn.onClick.AddListener(() => {
    //        LoadAudioMenu();
    //        AudioManager.instance.PlaySoundEffect(0); // 버튼 클릭 효과음 재생
    //    });

    //    GameplayPanelBtn.onClick.AddListener(() => {
    //        LoadGameplayMenu();
    //        AudioManager.instance.PlaySoundEffect(0); // 버튼 클릭 효과음 재생
    //    });

    //    ResetBtn.onClick.AddListener(() => {
    //        ResetSetting();
    //        AudioManager.instance.PlaySoundEffect(0); // 버튼 클릭 효과음 재생
    //    });

    //    //// TMP 드롭다운 값 변경 이벤트 설정
    //    //AudioManager.instance.MusicDropdown.onValueChanged.AddListener(delegate {AudioManager.instance.PlayBackgroundMusic(MusicDropdown.value);});

    //    //// 토글 값 변경 이벤트 설정
    //    //AudioManager.instance.BGMToggle.onValueChanged.AddListener(delegate { AudioManager.instance.ToggleBGM(BGMToggle.isOn); });
    //    //AudioManager.instance.SFXToggle.onValueChanged.AddListener(delegate { AudioManager.instance.ToggleSFX(SFXToggle.isOn); });

    //    //// 드롭다운 초기값 설정
    //    //AudioManager.instance.MusicDropdown.value = 0; //첫 번째 음악으로 설정
    //    //AudioManager.instance.VolumeDropdown.value = 2; // 음악 볼륨 초기값
    //}

    private void Update()
    {
        SaveSetting();
    }

    //private void LoadVideoMennu()
    //{
    //    VideoMenu.SetActive(true);
    //    GameplayMenu.SetActive(false);
    //    AudioMenu.SetActive(false);
    //}

    private void LoadSettings()
    {
        // 설정을 PlayerPrefs에서 불러와 UI 요소에 적용
        AudioManager.instance.BGMSlider.value = PlayerPrefs.GetFloat("BGMVolume", 0.5f);
        AudioManager.instance.SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.5f);

        AudioManager.instance.BGMMuteToggle.isOn = PlayerPrefs.GetInt("BGMMute", 0) == 1;
        AudioManager.instance.SFXMuteToggle.isOn = PlayerPrefs.GetInt("SFXMute", 0) == 1;

        AudioManager.instance.VolumeDropdown.value = AudioManager.instance.VolumeToDropdownIndex(AudioManager.instance.BGMSlider.value);
        AudioManager.instance.BGMDropdown.value = PlayerPrefs.GetInt("BGMMusicIndex", 0);
    }

    // 설정 초기화
    //private void ResetSetting()
    //{
    //    AudioManager.instance.BGMMuteToggle.isOn = false;
    //    AudioManager.instance.SFXMuteToggle.isOn = false;
    //    AudioManager.instance.BGMSlider.value = 0.5f;
    //    AudioManager.instance.SFXSlider.value = 0.5f;
    //    AudioManager.instance.SetBackgroundMusicVolume(0.5f);
    //    AudioManager.instance.SetSoundEffectVolume(0.5f);
    //    AudioManager.instance.ToggleBGM(false);
    //    AudioManager.instance.ToggleSFX(false);
    //}

    private void ResetSettings()
    {
        // 설정을 초기 상태로 재설정하고 PlayerPrefs에 저장
        AudioManager.instance.BGMMuteToggle.isOn = false;
        AudioManager.instance.SFXMuteToggle.isOn = false;
        AudioManager.instance.BGMSlider.value = 0.5f;
        AudioManager.instance.SFXSlider.value = 0.5f;

        AudioManager.instance.SetBackgroundMusicVolume(0.5f);
        AudioManager.instance.SetSoundEffectVolume(0.5f);
        AudioManager.instance.ToggleBGM(false);
        AudioManager.instance.ToggleSFX(false);

        AudioManager.instance.VolumeDropdown.value = AudioManager.instance.VolumeToDropdownIndex(0.5f);
    }

    // 게임플레이 메뉴 활성화
    private void LoadGameplayMenu()
    {
        GameplayMenu.SetActive(true);
        AudioMenu.SetActive(false);
        VideoMenu.SetActive(false);
    }

    // 오디오 메뉴 활성화
    private void LoadAudioMenu()
    {
        AudioMenu.SetActive(true);
        GameplayMenu.SetActive(false);
        VideoMenu.SetActive(false);
    }

    /*public void SetAllVolume(int index)
    {
        switch (index)
        {
            case 0:
                AudioManager.instance.backgroundMusicSource.volume = 0f;
                AudioManager.instance.soundEffectSource.volume = 0f;
                break;
            case 1:
                AudioManager.instance.backgroundMusicSource.volume = 0.25f;
                AudioManager.instance.soundEffectSource.volume = 0.25f;
                break;
            case 2:
                AudioManager.instance.backgroundMusicSource.volume = 0.5f;
                AudioManager.instance.soundEffectSource.volume = 0.5f;
                break;
            case 3:
                AudioManager.instance.backgroundMusicSource.volume = 0.75f;
                AudioManager.instance.soundEffectSource.volume = 0.75f;
                break;
            case 4:
                AudioManager.instance.backgroundMusicSource.volume = 1.0f;
                AudioManager.instance.soundEffectSource.volume = 1.0f;
                break;
        }
    }*/

    // 변경된 슬라이더 값 적용
    //public void UpdateSetting()
    //{
    //    if (PlayerPrefs.HasKey("BGMVolume"))
    //    {
    //        AudioManager.instance.BGMSlider.value = PlayerPrefs.GetFloat("BGMVolume");
    //        AudioManager.instance.SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    //    }
    //}

    // 슬라이더 값 저장
    public void SaveSetting()
    {
        PlayerPrefs.SetFloat("BGMVolume", AudioManager.instance.BGMSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", AudioManager.instance.SFXSlider.value);
        PlayerPrefs.SetInt("BGMMute", AudioManager.instance.BGMMuteToggle.isOn ? 1 : 0);
        PlayerPrefs.SetInt("SFXMute", AudioManager.instance.SFXMuteToggle.isOn ? 1 : 0);
    }
}
//    private float DropdownIndexToVolume(int index)
//    {
//        switch (index)
//        {
//            case 0: return 0f;
//            case 1: return 0.25f;
//            case 2: return 0.5f;
//            case 3: return 0.75f;
//            case 4: return 1f;
//            default: return 0.5f;
//        }
//    }

//    private int VolumeToDropdownIndex(float volume)
//    {
//        if (volume <= 0.125f) return 0;
//        if (volume <= 0.375f) return 1;
//        if (volume <= 0.625f) return 2;
//        if (volume <= 0.875f) return 3;
//        return 4;
//    }

//}
