using UnityEngine;

public class InOutGround : MonoBehaviour
{
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private float force;
    private InOutPattern inOutPattern;

    private void Awake()
    {
        inOutPattern = GetComponentInParent<InOutPattern>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(Utills.IsLayerMatched(targetLayer, other.gameObject.layer))
        {
            PlayerImpulseOnCollision player = other.GetComponent<PlayerImpulseOnCollision>();
            if (inOutPattern.IsPush)
            {
                player.ApplyImpulse(GameManager.Instance.Boss.transform.forward, force);
            }
            else
            {
                player.ApplyImpulse(-GameManager.Instance.Boss.transform.forward, force);
            }
        }
    }
}
