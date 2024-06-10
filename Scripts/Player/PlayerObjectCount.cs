using UnityEngine;

public class PlayerObjectCount : MonoBehaviour
{
    public int Count = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<WhiteBallObject>(out WhiteBallObject wbo))
        {
            Count = Mathf.Clamp(Count + 1, 0, 10);
            other.gameObject.SetActive(false);
        }
        else if(other.TryGetComponent<BlackBallObject>(out BlackBallObject bbo))
        {
            Count = Mathf.Clamp(Count - 1, 0, 10);
            other.gameObject.SetActive(false);
        }
    }
}
