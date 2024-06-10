using System.Collections.Generic;
using UnityEngine;

public class BossPatternIndicatorHandler : MonoBehaviour, IReadyOnlyPatternEvent
{
    [SerializeField] private List<GameObject> bossIndicators;

    private void Start()
    {
        GameManager.Instance.Boss.BossPatternHandler.OnReadyPattern += ReadyPattern;
    }


    public void ReadyPattern()
    {
        bossIndicators[GameManager.Instance.Boss.BossPatternHandler.PatternIdx].SetActive(true);
    }
}
