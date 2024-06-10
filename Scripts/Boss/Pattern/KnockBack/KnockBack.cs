using System.Collections;
using UnityEngine;
public class KnockBack : BossPattern, IStartPatternEvent
{
    [SerializeField] private float slashAngle;
    [SerializeField] private float slashDelay;
    private bool isFirst;
    Coroutine slashCoroutine;

    private void OnEnable()
    {
        isFirst = true;
        GameManager.Instance.Boss.BossPatternHandler.OnStartPattern += StartPattern;
        GameManager.Instance.Boss.BossPatternHandler.OnEndPattern += EndPattern;
    }

    //보스가 바라보는 방향으로 설정한 Delay마다 검기 발사

    public void StartPattern()
    {
        if(slashCoroutine != null)
        {
            StopCoroutine(slashCoroutine);
        }
        slashCoroutine = StartCoroutine(CreateSlash());
    }

    Quaternion additionalRotation;

    IEnumerator CreateSlash()
    {

        PoolObject slash = GameManager.Instance.Pool.SpawnFromPool(PoolObjectType.PatternKnockBack);
        additionalRotation = Quaternion.Euler(0, 0, slashAngle);
        slash.gameObject.transform.rotation *= additionalRotation;

        yield return new WaitForSecondsRealtime(slashDelay);

        PoolObject slash2 = GameManager.Instance.Pool.SpawnFromPool(PoolObjectType.PatternKnockBack);
        additionalRotation = Quaternion.Euler(0, 0, -slashAngle);
        slash2.gameObject.transform.rotation *= additionalRotation;

        yield return new WaitForSecondsRealtime(slash2.GetComponent<Slash>().MoveDuration);
        GameManager.Instance.Boss.BossPatternHandler.CallEndPattern();
    }

    public void EndPattern()
    {
        GameManager.Instance.Boss.BossPatternHandler.OnStartPattern -= StartPattern;
        GameManager.Instance.Boss.BossPatternHandler.OnEndPattern -= EndPattern;
        gameObject.SetActive(false);
    }
}
