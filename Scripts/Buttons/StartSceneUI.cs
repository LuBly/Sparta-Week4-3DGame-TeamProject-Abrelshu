using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class StartSceneUI : MonoBehaviour
{
    public Button StartBtn;
    public Button QuitBtn;
    public Button SettingBtn;
    public Button QuitSettingBtn;

    public GameObject SettingMenu;
    public GameObject StartMenu;

    void Start()
    {
        StartBtn.onClick.AddListener(() => {
            LoadMainScene();
            AudioManager.instance.PlaySoundEffect(0); // 버튼 클릭 시 효과음 재생
        });

        SettingBtn.onClick.AddListener(() => {
            LoadSetting();
            AudioManager.instance.PlaySoundEffect(0); // 버튼 클릭 효과음 재생
        });

        QuitBtn.onClick.AddListener(() => {
            QuitGame();
            AudioManager.instance.PlaySoundEffect(0); // 버튼 클릭 시 효과음 재생
        });

        QuitSettingBtn.onClick.AddListener(() => {
            QuitSetting();
            AudioManager.instance.PlaySoundEffect(0); // 버튼 클릭 시 효과음 재생
        });

        //// 초기 설정 상태 동기화
        //AudioManager.instance.BGMMuteToggle.isOn =  AudioManager.instance.BGMSource.mute;
        //AudioManager.instance.SFXMuteToggle.isOn =  AudioManager.instance.SFXSource.mute;
        //AudioManager.instance.BGMSlider.value = AudioManager.instance.BGMSource.volume;
        //AudioManager.instance.SFXSlider.value = AudioManager.instance.SFXSource.volume;

    }

    // 게임 시작
    private void LoadMainScene()
    {
        SceneManager.LoadScene(1);
    }

    // 게임 나가기
    private void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    // 설정 패널 열기
    private void LoadSetting()
    {
        //Time.timeScale = 0f;
        SettingMenu.SetActive(true);
        SettingBtn.interactable = false;
        StartBtn.interactable = false;
        QuitBtn.interactable = false;
    }

    private void QuitSetting()
    {
        SettingMenu.SetActive(false);
        SettingBtn.interactable = true;
        StartBtn.interactable = true;
        QuitBtn.interactable = true;
    }
}
