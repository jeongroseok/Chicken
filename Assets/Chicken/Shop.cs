using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chicken
{
    public partial class Shop : MonoBehaviour, IEnumerable<Product>, IDeliveryEndPoint
    {
        public event EventHandler<CoinEventArgs> CoinChanged;
        public event EventHandler DelivererChanged;
        
        private static Shop mainInstance;
        public static Shop Main
        {
            get
            {
                return mainInstance;
            }
        }

        [SerializeField]
        private Product[] products;
        [SerializeField]
        private Deliverer[] delivererPrefabs;
        [SerializeField]
        private Transform deliveryTarget;
        private DelivererManager delivererManager;
        private int coin;
        public int Coin
        {
            get { return coin; }
            private set
            {
                if (coin == value)
                    return;
                if (CoinChanged != null)
                {
                    CoinChanged(this, new CoinEventArgs(coin, value));
                }
                coin = value;
            }
        }
        
        public int DelivererCount {
            get
            {
                return delivererManager.Count;
            }
        }

        public IEnumerator<Product> Products { get { return new Enumerator(this); } }
        public Product RandomProduct
        {
            get
            {
                return products[UnityEngine.Random.Range(0, products.Length)];
            }
        }

        public Transform DeliveryTarget
        {
            get { return deliveryTarget; }
        }

        private void Awake()
        {
            Application.targetFrameRate = 60;
            mainInstance = this;
            delivererManager = new DelivererManager(this);
        }

        public bool TryOrder(OrderDetail detail)
        {
            var path = new Path(DeliveryTarget, detail.Customer.DeliveryTarget);
            return delivererManager.TryDeliver(detail, path);
        }
        
        public void AddNewDeliverer()
        {
            var newDeliverer = Instantiate(
                delivererPrefabs[UnityEngine.Random.Range(0, delivererPrefabs.Length)]);
            
            delivererManager.RegistryDeliverer(newDeliverer);
            if (DelivererChanged != null)
            {
                DelivererChanged(this, null);
            }
        }

        public IEnumerator<Product> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }
    }
}