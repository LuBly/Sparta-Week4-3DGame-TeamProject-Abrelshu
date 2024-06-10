using System.Collections;
using UnityEngine;

public class BallObject : PoolObject
{
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float disableDelay;
    Coroutine moveCoroutine;


    private void OnEnable()
    {
        if (moveCoroutine != null) 
        {
            StopCoroutine(moveCoroutine);
        }

        moveCoroutine = StartCoroutine(MoveBall());
    }

    protected virtual IEnumerator MoveBall()
    {
        float time = 0;

        while (time < disableDelay)
        {
            time += Time.deltaTime;

            // Apply both movements
            transform.Translate(transform.forward * moveSpeed * Time.deltaTime, Space.World);

            yield return null;
        }

        // 시간이 지나면 종료
        gameObject.SetActive(false);
    }
}
