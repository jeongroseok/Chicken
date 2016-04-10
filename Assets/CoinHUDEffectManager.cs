using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class CoinHUDEffectManager : MonoBehaviour {
    public static CoinHUDEffectManager Main { get; private set; }
    [SerializeField]
    private Text prefab;
    [SerializeField]
    private RectTransform canvasRectTransform;
    
    private void Awake()
    {
        Main = this;
    }
    
    public void Emit(int coinAmount, Vector3 position)
    {
        var t = Instantiate(prefab);
        t.rectTransform.SetParent(transform, false);
        t.text = coinAmount.ToString();

        Vector3 screenPos = Camera.main.WorldToViewportPoint(position);
        screenPos.x *= canvasRectTransform.rect.width;
        screenPos.y *= canvasRectTransform.rect.height;
        t.rectTransform.position = screenPos;
        
        t.DOFade(0, 1);
    }
}
