using UnityEngine;
using UnityEngine.UI;

public class SlideUIController : MonoBehaviour
{
    public Image SlideIcon;
    public Image FillAmountImage;
    public Text CooldownText;

    private PlayerSlideController playerSlideController;

    private void Start()
    {
        playerSlideController = FindObjectOfType<PlayerSlideController>();
    }

    private void Update()
    {
        float cooldownNormalized = playerSlideController != null ? playerSlideController.GetCooldownNormalized() : 0f;
        SetCooldown(cooldownNormalized);

        if (CooldownText != null && playerSlideController != null)
        {
            if (playerSlideController.IsCoolingDown())
            {
                UpdateCooldownText(); // 쿨다운 중일 때만 텍스트 업데이트 메서드 호출
                SlideIcon.enabled = true; // 활성화
            }
            else
            {
                CooldownText.text = ""; // 쿨다운 중이 아니면 텍스트 비우기
                SlideIcon.enabled = false; // 비활성화
            }
        }
    }

    public void SetCooldown(float cooldownNormalized)
    {
        FillAmountImage.fillAmount = cooldownNormalized;
    }

    private void UpdateCooldownText()
    {
        float remainingCooldown = playerSlideController.GetRemainingCooldown(); // 남은 쿨다운 시간 가져오기
        CooldownText.text = remainingCooldown.ToString("F1"); // 소수점 첫 번째 자리까지 표시
    }
}
