using UnityEngine;

public class BossAnimationEventHandler : MonoBehaviour
{
    public void ActivePattern()
    {
        GameManager.Instance.Boss.BossPatternHandler.UpdateChoosePattern();
    }

    public void CallStartPattern()
    {
        GameManager.Instance.Boss.BossPatternHandler.CallStartPattern();
    }

    public void CallEndPattern()
    {
        GameManager.Instance.Boss.BossPatternHandler.CallEndPattern();
    }
}
