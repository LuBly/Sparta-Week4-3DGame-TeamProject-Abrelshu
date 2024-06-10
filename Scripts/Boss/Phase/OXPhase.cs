using System.Collections;
using UnityEngine;

public class OXPhase : BossPhase // 1페이즈의 
{
    [Header("Phase Info Detail")]
    // hint가 나오기 까지의 Delay
    [SerializeField] private float hintDelay;
    [SerializeField] private float hintShowTime; 
    [SerializeField] private GameObject[] hintObject;
    
    [Header("Ball Info")]
    [SerializeField] private float createBallDelay;
    [SerializeField] private float minDistance;
    [SerializeField] private float maxDistance;
    [SerializeField] private float angleRange;

    [Header("Black Ball Info Detail")]
    [SerializeField] private int blackBallCount;
    [SerializeField] private float blackBallDelay; // 공들이 나오는 시간 delay 한번에 빡 x 

    [Header("White Ball Info Detail")]
    [SerializeField] private int whiteBallCount; // 반드시 짝수여야 한다
    [SerializeField] private float whiteBallAngle;

    [Header("Trigger Info Detail")]
    [SerializeField] private GameObject[] triggerObject;

    private int hintIdx;
    public int HintIdx => hintIdx;

    Coroutine createBallCoroutine;
    Coroutine hintCoroutine;

    Coroutine blackCoroutine;
    Coroutine whiteCoroutine;

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        handler.OnStart += StartPhase;
        handler.OnCheck += CheckPhase;
        handler.OnTrigger += EnableTrigger;
        handler.OnEnd += EndPhase;
    }


    // 페이즈 시작
    private void StartPhase()
    {
        if (createBallCoroutine != null) 
        {
            StopCoroutine(createBallCoroutine);
        }
        createBallCoroutine = StartCoroutine(CreateBall());

        if (hintCoroutine != null) 
        {
            StopCoroutine(hintCoroutine);
        }
        hintCoroutine = StartCoroutine(CreateHint());
    }
    
    IEnumerator CreateBall()
    {
        while (true)
        {
            if (blackCoroutine != null)
            {
                StopCoroutine(blackCoroutine);
            }
            blackCoroutine = StartCoroutine(CreateBlackBall());

            if(whiteCoroutine != null)
            {
                StopCoroutine(whiteCoroutine);
            }
            whiteCoroutine = StartCoroutine(CreateWhiteBall());
            
            yield return new WaitForSecondsRealtime(createBallDelay);
        }
    }

    IEnumerator CreateBlackBall()
    {
        for (int i = 0; i < blackBallCount; i++) 
        {
            float angle = transform.rotation.y + Random.Range(-angleRange, angleRange);
            float distance = Random.Range(minDistance,maxDistance);
            PoolObject blackBall = GameManager.Instance.Pool.SpawnFromPool(PoolObjectType.BlackBall);
            blackBall.transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
            blackBall.transform.position = blackBall.transform.forward * distance + Vector3.up;

            yield return new WaitForSecondsRealtime(blackBallDelay);
        }
    }

    IEnumerator CreateWhiteBall()
    {
        for (int i = 0; i < whiteBallCount / 2; i++)
        {
            float angle = transform.rotation.y + Random.Range(-angleRange, angleRange);
            float distance = Random.Range(minDistance, maxDistance);
            PoolObject white1 = GameManager.Instance.Pool.SpawnFromPool(PoolObjectType.WhiteBall);
            PoolObject white2 = GameManager.Instance.Pool.SpawnFromPool(PoolObjectType.WhiteBall);

            // 두 개의 구체를 동일한 위치에 생성
            white1.transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
            white2.transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));

            // 위치에 배치
            white1.transform.position = white1.transform.forward * distance + Vector3.up;
            white2.transform.position = white2.transform.forward * distance + Vector3.up;

            // 이동 방향 설정을 위해 조금씩 틀어주기
            white1.transform.rotation = Quaternion.Euler(new Vector3(0, angle + (whiteBallAngle / 2), 0));
            white2.transform.rotation = Quaternion.Euler(new Vector3(0, angle - (whiteBallAngle / 2), 0));

            yield return new WaitForSecondsRealtime(blackBallDelay);
        }
    }

    IEnumerator CreateHint()
    {
        hintIdx = Random.Range(0, hintObject.Length);
        yield return new WaitForSecondsRealtime(hintDelay);
        
        hintObject[hintIdx].gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(hintShowTime);

        hintObject[hintIdx].gameObject.SetActive(false);
    }

    private void EnableTrigger()
    {
        triggerObject[hintIdx].gameObject.SetActive(true);
    }

    //CheckPhase 시작되면 모든 공 생성 중단
    public void CheckPhase()
    {
        StopCoroutine(createBallCoroutine);
        StopCoroutine(blackCoroutine);
        StopCoroutine(whiteCoroutine);
    }

    // 페이즈 끝
    public void EndPhase()
    {
        StopCoroutine(hintCoroutine);
        handler.OnStart -= StartPhase;
        handler.OnCheck -= CheckPhase;
        handler.OnTrigger -= EnableTrigger;
        handler.OnEnd -= EndPhase;
        gameObject.SetActive(false);
    }
}