using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chicken
{
    public partial class Shop : MonoBehaviour
    {
        private class Enumerator : IEnumerator<Product>
        {
            private Shop shop;
            private int index = 0;

            public Enumerator(Shop shop)
            {
                this.shop = shop;
            }

            public Product Current { get { return shop.products[index]; } }

            object IEnumerator.Current { get { return Current; } }

            public void Dispose() { }

            public bool MoveNext()
            {
                return ++index < shop.products.Length;
            }

            public void Reset()
            {
                index = -1;
            }
        }
    }
}
