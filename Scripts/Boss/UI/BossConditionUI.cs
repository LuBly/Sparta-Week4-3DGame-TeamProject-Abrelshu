using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossConditionUI : MonoBehaviour
{
    [SerializeField] private Image curHealthBar;
    [SerializeField] private Image nextHealthBar;
    [SerializeField] private TextMeshProUGUI curHealthText;
    [SerializeField] private BossConditionHandler bossConditionHandler;
    [SerializeField] private BossPhaseHandler bossPhaseHandler;

    [Header("Colors")]
    [SerializeField] private List<Color> colors;

    private int idx = 0;
    private bool isPause = false;
    Coroutine pauseCoroutine;

    private void Start()
    {
        SetHealthBar();
        RepeatFillAmount();
        bossPhaseHandler.OnCheck += PauseFillAmount;
        bossPhaseHandler.OnEnd += RestartFillAmount;
    }

    private void PauseFillAmount()
    {
        isPause = true;
    }

    public void RestartFillAmount()
    {
        isPause = false;
        RepeatFillAmount();
    }

    private void RepeatFillAmount()
    {
        curHealthBar.fillAmount = 1;
        curHealthBar.DOFillAmount(0, bossConditionHandler.BossCondition.HealthDecayDelay).OnComplete(() =>
        {
            if(bossConditionHandler.CurHealth > 0 && !isPause)
            {
                idx++;
                bossConditionHandler.ChangeBossHealth(-1);
                SetHealthBar();
                RepeatFillAmount();
            }
        });
    }

    private void SetHealthBar()
    {
        SetHealthBarColor();
        SetHealthText();
    }

    private void SetHealthBarColor()
    {
        curHealthBar.color = colors[idx % colors.Count];
        nextHealthBar.color = colors[(idx + 1) % colors.Count];
        if (bossConditionHandler.CurHealth == 0)
            nextHealthBar.color = new Color(0, 0, 0, 0);
    }

    private void SetHealthText()
    {
        curHealthText.text = "X " + bossConditionHandler.CurHealth.ToString();
    }
}
