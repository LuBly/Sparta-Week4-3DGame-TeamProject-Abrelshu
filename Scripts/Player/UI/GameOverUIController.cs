using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUIController : MonoBehaviour
{
    public void DisplayGameOverUI()
    {
        Debug.Log("당신 죽었으니까 제발 판넬 나와주세요");
        GameManager.Instance.IsGameOver = true;
        gameObject.SetActive(true);
        Debug.Log(gameObject.activeSelf);
    }

    public void OnHomeBtn()
    {
        DOTween.KillAll();
        SceneManager.LoadScene(0);
    }

    public void OnRetryBtn()
    {
        DOTween.KillAll();
        SceneManager.LoadScene(1);
    }
}
