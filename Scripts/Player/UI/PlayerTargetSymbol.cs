using UnityEngine;
using UnityEngine.UI;

public class PlayerTargetSymbol : MonoBehaviour
{
    [Header("Symbol")]
    [SerializeField] private Sprite[] SymbolSprites;
    
    private Image SymbolImage;

    private int _targetSymbolNum;

    private void Awake()
    {
        SymbolImage = GetComponent<Image>();
    }

    public int CreateSymbolSprite()
    {
        _targetSymbolNum = Random.Range(0, SymbolSprites.Length); // 배열 범위
        SymbolImage.sprite = SymbolSprites[_targetSymbolNum];
        return _targetSymbolNum;
    }
}
