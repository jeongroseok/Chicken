using System;
using UnityEngine;
using UnityEngine.UI;

namespace Chicken.UI
{
    public class UIDelivererCountViewer : MonoBehaviour
    {
        [SerializeField]
        private Text text;

        private void Awake()
        {
            Shop.Main.DelivererChanged += OnDelivererChanged;
        }

        private void OnDelivererChanged(object sender, EventArgs e)
        {
            text.text = Shop.Main.DelivererCount.ToString();
        }
    }
}