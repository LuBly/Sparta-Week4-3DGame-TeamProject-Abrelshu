using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private PoolManager poolManager;
    [SerializeField] private Boss boss;
    [SerializeField] private GameObject clearPanel;
    public PoolManager Pool => poolManager;
    public Boss Boss => boss;
    public bool IsGameOver; // 사망 처리 되는 부분이 => 

    private void Awake()
    {
        AudioManager.instance.FindAudioComponents();
        IsGameOver = false;
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CallOnClear()
    {
        IsGameOver = true;
        clearPanel.gameObject.SetActive(true);
        boss.gameObject.SetActive(false);
    }
}