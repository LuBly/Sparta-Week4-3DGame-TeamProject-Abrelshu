using System;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField] private GameObject cameraObject;

    private void Start()
    {
        GameManager.Instance.Boss.BossPhaseHandler.OnCheck += CameraOut;
        GameManager.Instance.Boss.BossPhaseHandler.OnEnd += CameraIn;
    }

    private void CameraOut()
    {
        cameraObject.SetActive(true);
    }

    private void CameraIn()
    {
        cameraObject.SetActive(false);
    }
}
