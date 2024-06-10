using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class BossAlertUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI alertText;

    Coroutine alertCoroutine;
    float countDownTime;

    private void Start()
    {
        GameManager.Instance.Boss.BossPhaseHandler.OnCheck += SetAlertTimer;
    }

    private void SetAlertTimer()
    {
        if(alertCoroutine != null)
        {
            StopCoroutine(alertCoroutine);
        }
        alertCoroutine = StartCoroutine(StartAlertTimer());
    }

    IEnumerator StartAlertTimer()
    {
        countDownTime = GameManager.Instance.Boss.BossPhaseHandler.CountDownTime;
        alertText.gameObject.SetActive(true);
        while(countDownTime >= 0)
        {
            alertText.text = countDownTime.ToString();
            countDownTime--;
            yield return new WaitForSecondsRealtime(1f);
        }
        alertText.gameObject.SetActive(false);

        GameManager.Instance.Boss.BossPhaseHandler.CallTrigger();
    }
}
