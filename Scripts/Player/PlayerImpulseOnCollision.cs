using UnityEngine;

public class PlayerImpulseOnCollision : MonoBehaviour
{
    private Rigidbody playerRigidbody;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>(); // Player의 Rigidbody 컴포넌트 가져오기
    }

    // 충돌 시 플레이어 밀어내기
    public void ApplyImpulse(Vector3 dir, float force)
    {
        if (playerRigidbody != null)
        {
            playerRigidbody.velocity = Vector3.zero;

            // 힘을 적용하여 플레이어를 밀어냄
            playerRigidbody.AddForce(dir * force, ForceMode.Impulse);
        }
    }
}
