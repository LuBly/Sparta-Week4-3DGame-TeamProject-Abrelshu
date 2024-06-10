using System;
using System.Collections.Generic;
using UnityEngine;

public class BossPhaseHandler : MonoBehaviour
{
    [SerializeField] private List<BossPhase> bossPhaseList;
    private int curPhaseIdx = 0;
    private PhaseType phaseType;
    public int CurPhaseIdx { get; private set; }
    public int StartHP { get; private set; }
    public int EndHP { get; private set; }
    public float CountDownTime { get; private set; }
    public PhaseType PhaseType { get; private set; }

    public event Action OnStart;
    public event Action OnCheck;   // 카운트 다운 시작
    public event Action OnTrigger; // 트리거 떨어뜨리기
    public event Action OnEnd;     // PhaseEnd 다음 페이즈 시작

    private void Awake()
    {
        StartHP = bossPhaseList[curPhaseIdx].StartHP;
        EndHP = bossPhaseList[curPhaseIdx].EndHP;
        CountDownTime = bossPhaseList[curPhaseIdx].CountDownTime;
        PhaseType = bossPhaseList[curPhaseIdx].PhaseType;
    }

    public void StartPhase()
    {
        bossPhaseList[curPhaseIdx].gameObject.SetActive(true);
        CallStartPhase();
    }
    public void EndPhase()
    {
        curPhaseIdx++;
        // curPhaseIdx가 지금 있는 Phase들의 카운트보다 작으면 Count++ 크면 마무리
        if (curPhaseIdx < bossPhaseList.Count)
        {
            StartHP = bossPhaseList[curPhaseIdx].StartHP;
            EndHP = bossPhaseList[curPhaseIdx].EndHP;
            CountDownTime = bossPhaseList[curPhaseIdx].CountDownTime;
        }
        CallEndPhase();
    }
    public void CallStartPhase()
    {
        OnStart?.Invoke();
    }
    public void CallCheckPhase()
    {
        OnCheck?.Invoke();
    }

    public void CallTrigger()
    {
        OnTrigger?.Invoke();
    }

    public void CallEndPhase()
    {
        OnEnd?.Invoke();
    }
}
