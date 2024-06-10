using DG.Tweening;
using System;
using UnityEngine;

public class Slash : PoolObject
{
    [SerializeField] private float moveSpeed; // 이동 속도
    [SerializeField] private float moveDuration; // 이동 시간
    [SerializeField] private float knockbackForce; // 넉백 힘
    [SerializeField] private LayerMask targetLayer;

    public float MoveDuration => moveDuration;
    public Quaternion targetQuaternion;

    private void OnEnable()
    {
        transform.rotation = GameManager.Instance.Boss.gameObject.transform.rotation;
        transform.position = Vector3.up * 6;
        MoveForward();
    }

    private void MoveForward()
    {
        Vector3 targetPosition = transform.forward * (moveSpeed * moveDuration);

        transform.DOMove(targetPosition, moveDuration).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }

    private void OnTriggerEnter(Collider other)
    {
        if(Utills.IsLayerMatched(targetLayer, other.gameObject.layer))
        {
            // Player 넉백
            Debug.Log("플레이어 넉백" + transform.forward);

            // PlayerImpulseOnCollision 컴포넌트를 찾아 ApplyImpulse 함수 호출
            PlayerImpulseOnCollision playerImpulse = other.GetComponent<PlayerImpulseOnCollision>();
            if (playerImpulse != null)
            {
                playerImpulse.ApplyImpulse(transform.forward, knockbackForce);
            }
        }
    }

    private void OnDisable()
    {
        DOTween.Kill(transform);
    }
}
