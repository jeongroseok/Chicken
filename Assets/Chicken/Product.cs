using System;
using UnityEngine;

namespace Chicken
{
    [CreateAssetMenu]
    public class Product : ScriptableObject
    {
        [SerializeField]
        private int price;
        
        public int Price { get { return price; } }
    }
}

