using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuillotineUI : MonoBehaviour
{
    [SerializeField] private List<Image> fillAmountImages;
    [SerializeField] private Guillotine guillotine;

    private void OnEnable()
    {
        guillotine.RotateTowardsRoute(transform);
        transform.position = SetIndicatorPosition();
        FillIndicator();
    }

    private Vector3 SetIndicatorPosition()
    {
        Vector3 pos = (guillotine.routes[guillotine.routeIdx].start.position + guillotine.routes[guillotine.routeIdx].destination.position)/2;
        pos += Vector3.down * 29.9f;
        return pos;
    }

    private void FillIndicator()
    {
        fillAmountImages[0].fillAmount = 0;
        fillAmountImages[1].fillAmount = 0;
        fillAmountImages[0].DOFillAmount(1, GameManager.Instance.Boss.BossPatternHandler.IndicatorDelay);
        fillAmountImages[1].DOFillAmount(1, GameManager.Instance.Boss.BossPatternHandler.IndicatorDelay).OnComplete(() =>
        {
            GameManager.Instance.Boss.BossPatternHandler.CallStartPattern();
            gameObject.SetActive(false);
        });
    }

    private void OnDisable()
    {
        DOTween.Kill(fillAmountImages);
    }
}
