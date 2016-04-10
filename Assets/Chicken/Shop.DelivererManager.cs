using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chicken
{
    public partial class Shop : MonoBehaviour
    {
        private class DelivererManager
        {
            private List<Deliverer> allDeliverers;
            private List<Deliverer> usableDeliverers;
            private Shop shop;

            public int Count { get { return allDeliverers.Count; } }

            public DelivererManager(Shop shop)
            {
                this.shop = shop;
                allDeliverers = new List<Deliverer>();
                usableDeliverers = new List<Deliverer>();
            }

            internal bool TryDeliver(OrderDetail detail, Path path)
            {
                if (usableDeliverers.Count <= 0)
                {
                    return false;
                }
                var deliverer = usableDeliverers[UnityEngine.Random.Range(0, usableDeliverers.Count)];
                deliverer.Deliver(detail, path);
                usableDeliverers.Remove(deliverer);
                return true;
            }

            internal void RegistryDeliverer(Deliverer newDeliverer)
            {
                allDeliverers.Add(newDeliverer);
                usableDeliverers.Add(newDeliverer);
                newDeliverer.DeliveryEnd += OnDeliveryEnd;
                newDeliverer.gameObject.SetActive(false);
            }

            private void OnDeliveryEnd(object sender, EventArgs args)
            {
                var deliverer = sender as Deliverer;
                if (allDeliverers.Contains(deliverer))
                {
                    if (!usableDeliverers.Contains(deliverer))
                    {
                        usableDeliverers.Add(deliverer);
                        deliverer.gameObject.SetActive(false);
                        shop.Coin += deliverer.Detail.Product.Price;
                    }
                }
            }

            internal void UnRegistryDeliverer(Deliverer newDeliverer)
            {
                allDeliverers.Remove(newDeliverer);
                usableDeliverers.Remove(newDeliverer);
            }
        }
    }
}
