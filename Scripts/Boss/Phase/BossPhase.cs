using UnityEngine;

public class BossPhase : MonoBehaviour
{
    [Header("Phase Info")]
    [SerializeField] private int startHP;
    [SerializeField] private int endHP;
    [SerializeField] private float countDownTime;
    [SerializeField] private PhaseType phaseType;

    public int StartHP => startHP;
    public int EndHP => endHP;
    public float CountDownTime => countDownTime;
    public PhaseType PhaseType => phaseType;

    protected BossPhaseHandler handler;
    protected virtual void Awake()
    {
        handler = GetComponentInParent<BossPhaseHandler>();
    }
}
