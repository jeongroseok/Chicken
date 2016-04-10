using UnityEngine;

namespace Chicken
{
    public interface IDeliveryEndPoint
    {
        Transform DeliveryTarget { get; }
    }
}