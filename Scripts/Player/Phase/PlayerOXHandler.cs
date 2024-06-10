using UnityEngine;
public class PlayerOXHandler : PlayerPhaseHandler
{
    [SerializeField] private PlayerCurrentSymbol playerCurrentSymbol;
    [SerializeField] private PlayerTargetSymbol playerTargetSymbol;

    private int targetSymbolNum;
    public int TargetSymbolNum => targetSymbolNum;

    private void OnEnable()
    {
        playerCurrentSymbol.PlayerObjectCount.Count = 0;
        targetSymbolNum = playerTargetSymbol.CreateSymbolSprite();
    }

    public override bool CheckPass()
    {
        return (float)((playerCurrentSymbol.PlayerObjectCount.Count / 2.0f) - 1.0f) == targetSymbolNum;
    }
}
