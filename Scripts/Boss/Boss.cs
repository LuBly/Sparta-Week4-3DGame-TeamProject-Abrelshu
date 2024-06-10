using UnityEngine;

public class Boss : MonoBehaviour
{
    public BossConditionHandler BossConditionHandler { get; private set; }
    public BossPhaseHandler BossPhaseHandler { get; private set; }
    public BossPatternHandler BossPatternHandler { get; private set; }

    private void Awake()
    {
        BossConditionHandler = GetComponent<BossConditionHandler>();
        BossPhaseHandler = GetComponent<BossPhaseHandler>();
        BossPatternHandler = GetComponent<BossPatternHandler>();
    }
}
