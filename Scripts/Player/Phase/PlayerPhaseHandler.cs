using UnityEngine;

public abstract class PlayerPhaseHandler : MonoBehaviour
{
    protected bool isPass;

    public abstract bool CheckPass();
}
