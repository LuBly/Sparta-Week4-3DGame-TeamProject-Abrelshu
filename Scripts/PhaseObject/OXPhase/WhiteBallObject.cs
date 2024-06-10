using System.Collections;
using UnityEngine;

public class WhiteBallObject : BallObject
{
    [SerializeField] private float moveDelay;
    protected override IEnumerator MoveBall()
    {
        yield return new WaitForSecondsRealtime(moveDelay);
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