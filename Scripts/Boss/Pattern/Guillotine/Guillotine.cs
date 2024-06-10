using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;
public class Guillotine : BossPattern, IStartPatternEvent
{
    [Serializable]
    public struct Route
    {
        public Transform start;
        public Transform destination;
    }

    [SerializeField] private float moveDuring;
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private GameOverUIController gameOverUIController;

    public List<Route> routes;
    public int routeIdx;

    public Vector3 GetRouteAngle()
    {
        routeIdx = UnityEngine.Random.Range(0, routes.Count);
        Vector3 start = routes[routeIdx].start.position;
        Vector3 dest = routes[routeIdx].destination.position;
        Vector3 dir = (dest - start).normalized;
        return dir;
    }

    public void RotateTowardsRoute(Transform trans)
    {
        Vector3 direction = GetRouteAngle();
        if(direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            trans.rotation = targetRotation;
            transform.rotation = targetRotation;
        }
    }

    private void InitGuillotine()
    {
        transform.position = routes[routeIdx].start.position;
        Vector3 localRotation = transform.localEulerAngles;
        localRotation.x += 45f;
        transform.localEulerAngles = localRotation;
    }

    public void StartPattern()
    {
        Vector3 targetRotation = transform.localEulerAngles;
        targetRotation.x -= 90f;

        transform.DOMove(routes[routeIdx].destination.position, moveDuring);
        transform.DORotate(targetRotation, moveDuring).OnComplete(() => 
        {
            gameObject.SetActive(false);
        });
    }

    public void EndPattern()
    {
        GameManager.Instance.Boss.BossPatternHandler.OnStartPattern -= StartPattern;
        GameManager.Instance.Boss.BossPatternHandler.OnEndPattern -= EndPattern;
    }

    private void OnEnable()
    {
        InitGuillotine();
        GameManager.Instance.Boss.BossPatternHandler.OnStartPattern += StartPattern;
        GameManager.Instance.Boss.BossPatternHandler.OnEndPattern += EndPattern;
    }

    private void OnDisable()
    {
        EndPattern();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(IsLayerMatched(targetLayer, other.gameObject.layer))
        {
            Debug.Log("뒤졌콩ㅋ");
            gameOverUIController.DisplayGameOverUI();
        }
    }

    private bool IsLayerMatched(int layerMask, int objectLayer)
    {
        return layerMask == (layerMask | (1 << objectLayer));
    }
}
