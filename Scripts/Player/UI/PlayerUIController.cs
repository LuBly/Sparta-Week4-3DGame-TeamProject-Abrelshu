using System.Collections.Generic;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] private BossPhaseHandler bossPhaseHandler;
    [SerializeField] private List<GameObject> PlayerUI; // 0 = OX, 1 = Center, 2 = Think


    private void Start()
    {
        bossPhaseHandler.OnStart += EnableUI;
        bossPhaseHandler.OnEnd += DisableUI;
    }

    private void EnableUI()
    {
        PlayerUI[(int)bossPhaseHandler.PhaseType].gameObject.SetActive(true);
    }

    private void DisableUI()
    {
        PlayerUI[(int)bossPhaseHandler.PhaseType].gameObject.SetActive(false);
    }
}
