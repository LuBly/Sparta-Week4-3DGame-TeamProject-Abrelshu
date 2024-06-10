using UnityEngine;
using UnityEngine.UI;

public class PlayerCurrentSymbol : MonoBehaviour
{
    public Image SymbolImage;
    public PlayerObjectCount PlayerObjectCount;

    [Header("Symbol")]
    public Sprite[] SymbolSprites;

    private void Start()
    {
        SymbolImage = GetComponent<Image>();
    }

    void Update()
    {
        UpdateSymbolSprite(PlayerObjectCount.Count);
    }

    void UpdateSymbolSprite(int count)
    {
        switch (count)
        {
            case 2:
                SymbolImage.sprite = SymbolSprites[0];
                SymbolImage.enabled = true;
                break;
            case 4:
                SymbolImage.sprite = SymbolSprites[1];
                SymbolImage.enabled = true;
                break;
            case 6:
                SymbolImage.sprite = SymbolSprites[2];
                SymbolImage.enabled = true;
                break;
            case 8:
                SymbolImage.sprite = SymbolSprites[3];
                SymbolImage.enabled = true;
                break;
            default:
                SymbolImage.sprite = null;
                SymbolImage.enabled = false;
                break;
        }
    }
}
