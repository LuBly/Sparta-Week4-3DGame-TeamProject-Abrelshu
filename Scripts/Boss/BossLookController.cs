using UnityEngine;

public class BossLookController : MonoBehaviour
{
    private void Update()
    {
        transform.LookAt(CharacterManager.Instance.Player.transform.position);
    }
}