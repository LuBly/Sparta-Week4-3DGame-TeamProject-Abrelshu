using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneUI : MonoBehaviour
{
    public Button SettingBtn;
    public Button QuitSettingBtn;

    public GameObject SettingMenu;

    private void Start()
    {
        SettingBtn.onClick.AddListener(() => {
            LoadSetting();
            AudioManager.instance.PlaySoundEffect(0); // 버튼 클릭 시 효과음 재생
        });

        QuitSettingBtn.onClick.AddListener(() => {
            QuitSetting();
            AudioManager.instance.PlaySoundEffect(0); // 버튼 클릭 효과음 재생
        });
    }

    private void LoadSetting()
    {
        //Time.timeScale = 0f;
        SettingMenu.gameObject.SetActive(true);
        SettingBtn.interactable = false;
    }

    private void QuitSetting()
    {
        //Time.timeScale = 1f;
        SettingMenu.SetActive(false);
        SettingBtn.interactable = true;
    }
}
