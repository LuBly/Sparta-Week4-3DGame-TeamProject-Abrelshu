using UnityEngine;

public class BossConditionHandler : MonoBehaviour
{
    public BossCondition BossCondition;
    private BossPhaseHandler bossPhaseHandler;
    public int CurHealth {  get; private set; }
    
    private void Awake()
    {
        bossPhaseHandler = GetComponent<BossPhaseHandler>();
        CurHealth = BossCondition.MaxHealth;
    }

    // 옵저버
    public void ChangeBossHealth(int amount)
    {
        if (CurHealth == bossPhaseHandler.StartHP)
            bossPhaseHandler.StartPhase();
        
        CurHealth += amount;
        
        if(CurHealth == bossPhaseHandler.EndHP)
            bossPhaseHandler.CallCheckPhase();

        if (CurHealth == 0)
        {
            GameManager.Instance.CallOnClear();
        }
    }
}