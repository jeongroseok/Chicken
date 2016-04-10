using UnityEngine;
using UnityEngine.UI;

namespace Chicken.UI
{
    public class UICoinViwer : MonoBehaviour
    {
        [SerializeField]
        private Text text;

        private void Awake()
        {
            Shop.Main.CoinChanged += OnCoinChanged;
        }

        private void OnCoinChanged(object sender, CoinEventArgs e)
        {
            text.text = e.New.ToString();
        }
    }
}