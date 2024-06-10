using UnityEngine;

public class OXTriggerObject : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private BossPhaseHandler bossPhaseHandler;
    [SerializeField] private PlayerOXHandler playerOXHandler;
    [SerializeField] private GameOverUIController gameOverUIController;

    private void OnEnable()
    {
        // Player의 targetSymbol Idx에 따라 각도 회전
        float angle = 90 * playerOXHandler.TargetSymbolNum;
        transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
        transform.position = Vector3.up * 20;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(IsLayerMatched(playerLayer, other.gameObject.layer))
        {
            Debug.Log("앗코 맞아버렸당");
            CallPlayerDeath();
            gameObject.SetActive(false);
        }

        if (IsLayerMatched(groundLayer, other.gameObject.layer))
        {
            Debug.Log("바닥 닿았지롱");

            if (!CheckPlayerSymbol())
            {
                Debug.Log("문양 맞추기 실패");
                CallPlayerDeath();
            }
            else
            {
                Debug.Log("문양 맞추기 성공");
                //Debug.Log("Player 생존");
            }

            bossPhaseHandler.EndPhase();
            gameObject.SetActive(false);
        }
    }

    private bool IsLayerMatched(int layerMask, int objectLayer)
    {
        return layerMask == (layerMask | (1 << objectLayer));
    }

    private bool CheckPlayerSymbol()
    {
        // Player가 문양을 맞췄는지 확인
        return playerOXHandler.CheckPass();
    }

    private void CallPlayerDeath()
    {
        Debug.Log("Player 사망");
        gameOverUIController.DisplayGameOverUI();
    }
}
