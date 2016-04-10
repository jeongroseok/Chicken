using UnityEngine;
using System.Collections;
using System;

namespace Chicken
{
    public class DeliveryEffector : MonoBehaviour
    {
        [SerializeField]
        private GameObject effect;
        
        private void Awake()
        {
            var deliverer = GetComponent<Deliverer>();
            deliverer.DeliveryEnd += OnDeliveryEnd;
        }
        
        private void OnDeliveryEnd(object sender, EventArgs args)
        {
            var d = sender as Deliverer;
            CoinHUDEffectManager.Main.Emit(d.Detail.Product.Price, transform.position);
            Instantiate(effect).transform.position = transform.position;
        }
    }

}