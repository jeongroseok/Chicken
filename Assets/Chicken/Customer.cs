using System;
using System.Collections;
using UnityEngine;

namespace Chicken
{
    public class Customer : MonoBehaviour, IDeliveryEndPoint
    {
        public event EventHandler Ordered;

        [SerializeField]
        private Shop shop;
        [SerializeField]
        private float orderSpeed;
        [SerializeField]
        private Transform deliveryTarget;

        public Transform DeliveryTarget
        {
            get { return deliveryTarget; }
        }

        private IEnumerator Start()
        {
            float lastOrderTime = Time.time;
            while (true)
            {
                float orderTime = 1.0f / orderSpeed;
                while (Time.time - lastOrderTime < orderTime)
                    yield return null;
                
                NewOrder();
                lastOrderTime = Time.time;
            }
        }

        private void NewOrder()
        {
            var shop = Shop.Main;
            var product = shop.RandomProduct;
            var result = Shop.Main.TryOrder(new OrderDetail(this, product));
            
            if (Ordered != null && result)
            {
                Ordered(this, EventArgs.Empty);
            }
        }
    }
}