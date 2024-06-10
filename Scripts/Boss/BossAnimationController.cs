using System;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimationController : MonoBehaviour, IReadyOnlyPatternEvent
{
    private Animator animator;
    private BossPatternHandler bossPatternHandler;

    private readonly int oxPhaseUp = Animator.StringToHash("OXPhaseUp");
    private readonly int oxPhaseDown = Animator.StringToHash("OXPhaseDown");

    private readonly List<int> patterns = new List<int>()
    {
        Animator.StringToHash("Pattern1"),
        Animator.StringToHash("Pattern2"),
        Animator.StringToHash("Pattern3")
    };

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        bossPatternHandler = GetComponent<BossPatternHandler>();
    }

    private void Start()
    {
        bossPatternHandler.OnReadyPattern += ReadyPattern;
        GameManager.Instance.Boss.BossPhaseHandler.OnCheck += FlyUP;
        GameManager.Instance.Boss.BossPhaseHandler.OnEnd += FlyDown;
    }


    private void FlyUP()
    {
        animator.SetTrigger(oxPhaseUp);
    }

    private void FlyDown()
    {
        animator.SetTrigger(oxPhaseDown);
    }

    public void ReadyPattern()
    {
        int curPatternIdx = bossPatternHandler.PatternIdx;
        animator.SetTrigger(patterns[curPatternIdx]);
    }
}