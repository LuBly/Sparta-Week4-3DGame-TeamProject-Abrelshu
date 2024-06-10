using System.Collections;
using UnityEngine;

public class InOutUI : MonoBehaviour 
{ 
    [SerializeField] private InOutPattern inOutPattern;
    private Animator animator;
    private Coroutine uiCoroutine;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        if(uiCoroutine != null)
        {
            StopCoroutine(uiCoroutine);
        }
        uiCoroutine = StartCoroutine(UICounter());
    }

    IEnumerator UICounter()
    {
        if (inOutPattern.SetIsPush())
        {
            animator.SetFloat("speed", -1);
        }
        else
        {
            animator.SetFloat("speed", 1);
        }

        yield return new WaitForSecondsRealtime(inOutPattern.IndicatorDelay);

        GameManager.Instance.Boss.BossPatternHandler.CallStartPattern();
        gameObject.SetActive(false);
    }
}
