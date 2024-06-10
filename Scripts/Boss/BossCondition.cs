using System;

[Serializable]
public class BossCondition
{
    public int MaxHealth;
    // 몇 초당 한 줄 씩 체력이 감소하는지에 대한 정보
    public float HealthDecayDelay;
}
