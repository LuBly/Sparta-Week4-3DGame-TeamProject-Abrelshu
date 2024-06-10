using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VideoBtn : MonoBehaviour
{
    TMP_Dropdown ResolutionDropdown;

    private void Start()
    {
        ResolutionDropdown = GetComponent<TMP_Dropdown>();
    }
    public void ChangeScreenResolution(int index)
    {
        switch (index)
        {
            case 0:
                Screen.SetResolution(1366, 768, true); 
                break;
            case 1:
                Screen.SetResolution(1920, 1080, true);
                break;
            case 2:
                Screen.SetResolution(2560, 1440, true); 
                break;
            case 3:
                Screen.SetResolution(3840, 2160, true);
                break;
            //default:
            //    Screen.SetResolution(1920, 1080, true); 
            //    break;
        }
    }
}
