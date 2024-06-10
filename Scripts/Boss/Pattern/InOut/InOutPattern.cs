using System.Collections;
using UnityEngine;
public class InOutPattern : BossPattern, IStartPatternEvent
{
    private ParticleSystem patternEffect;
    private Coroutine effectCoroutine;
    private bool isPush;
    public bool IsPush => isPush;

    private void Awake()
    {
        patternEffect = GetComponentInChildren<ParticleSystem>();        
    }

    private void OnEnable()
    {
        GameManager.Instance.Boss.BossPatternHandler.OnStartPattern += StartPattern;
        GameManager.Instance.Boss.BossPatternHandler.OnEndPattern += EndPattern;
    }

    public bool SetIsPush()
    {
        int isPush_Int = Random.Range(0, 2);
        if (isPush_Int == 0) isPush = true;
        else isPush = false;

        return isPush;
    }

    public void StartPattern()
    {
        if (effectCoroutine != null)
        {
            StopCoroutine(effectCoroutine);
        }
        effectCoroutine = StartCoroutine(ActiveEffect());
        
    }

    IEnumerator ActiveEffect()
    {
        Debug.Log(isPush);
        if (isPush) Debug.Log("밀었당!");
        else Debug.Log("당겼당!");
        yield return new WaitForSecondsRealtime(patternEffect.main.duration);
        gameObject.SetActive(false);
        GameManager.Instance.Boss.BossPatternHandler.CallEndPattern();
    }

    public void EndPattern()
    {
        GameManager.Instance.Boss.BossPatternHandler.OnStartPattern -= StartPattern;
        GameManager.Instance.Boss.BossPatternHandler.OnEndPattern -= EndPattern;
    }
}