using UnityEngine;

public class TriggerEffect : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        audioSource.Play(); // 효과음 재생
    }
}
