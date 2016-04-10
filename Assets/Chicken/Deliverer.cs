using UnityEngine;
using DG.Tweening;
using System;

namespace Chicken
{
    public class Deliverer : PathAnimator
    {
        public event EventHandler DeliveryStart;
        public event EventHandler DeliveryEnd;
        
        private Vector3 oldPosition;
        private bool deliveredSuccess = false;
        private Path path;
        private OrderDetail detail;

        public OrderDetail Detail { get { return detail; } }

        private void Awake()
        {
            base.MoveEnd += OnMoveEnd;
        }

        public void Deliver(OrderDetail detail, Path path)
        {
            gameObject.SetActive(true);
            this.path = path;
            this.detail = detail;
            
            deliveredSuccess = false;
            Play(new Path(path.From, path.To));
        }

        private void OnMoveEnd(object sender, EventArgs args)
        {
            if (!deliveredSuccess)
            {
                Play(new Path(path.To, path.From));
                deliveredSuccess = true;
            }
            else
            {
                if (DeliveryEnd != null)
                {
                    DeliveryEnd(this, EventArgs.Empty);
                }
            }
        }

        private void Update()
        {
            var direction = transform.position - oldPosition;
            direction.Normalize();
            transform.localRotation = Quaternion.LookRotation(direction);

            oldPosition = transform.position;
        }
    }
}