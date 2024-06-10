using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatternHandler : MonoBehaviour
{
    [SerializeField] private List<BossPattern> patterns;
    [SerializeField] private float patternDelay;
    private BossPhaseHandler bossPhaseHandler;
    private Coroutine patternCoroutine;
    private float randomDelay;

    private int patternIdx;
    public int PatternIdx => patternIdx;

    private float indicatorDelay;
    public float IndicatorDelay => indicatorDelay;

    public event Action OnReadyPattern;
    public event Action OnStartPattern;
    public event Action OnEndPattern;

    private void Awake()
    {
        bossPhaseHandler = GetComponent<BossPhaseHandler>();
    }

    private void Start()
    {
        bossPhaseHandler.OnCheck += StopPattern;
    }

    private void StopPattern()
    {
        StopCoroutine(patternCoroutine);
    }

    public void UpdateChoosePattern()
    {
        if (patternCoroutine != null)
        {
            StopCoroutine(patternCoroutine);
        }
        patternCoroutine = StartCoroutine(ChoosePattern());
    }

    IEnumerator ChoosePattern()
    {
        yield return new WaitForSecondsRealtime(.5f);
        while (true)
        {
            patternIdx = UnityEngine.Random.Range(0, patterns.Count);
            indicatorDelay = patterns[patternIdx].IndicatorDelay;
            randomDelay = UnityEngine.Random.Range(-1f, 1f);
            CallReadyPattern();
            yield return new WaitForSecondsRealtime(patternDelay + randomDelay);
        }
    }

    public void CallReadyPattern()
    {
        Debug.Log("ImReady");
        OnReadyPattern?.Invoke();
    }

    public void CallStartPattern()
    {
        patterns[patternIdx].gameObject.SetActive(true);
        OnStartPattern?.Invoke();
    }

    public void CallEndPattern()
    {
        OnEndPattern?.Invoke();
    }
}
