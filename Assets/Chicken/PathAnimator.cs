using UnityEngine;
using DG.Tweening;
using System;

namespace Chicken
{
    public class PathAnimator : MonoBehaviour
    {
        public event EventHandler MoveStart;
        public event EventHandler MoveEnd;

        [SerializeField]
        private float speed = 1;

        public void Play(Path path)
        {
            float duration = path.Distance * (1.0f / speed);
            Sequence seq = DOTween.Sequence();
            Ease ease = Ease.Linear;

            Tween tween = transform.DOMove(path.To.position, duration);
            tween.SetEase(ease);
            tween.OnComplete(() =>
                {
                    if (MoveEnd != null)
                    {
                        MoveEnd(this, EventArgs.Empty);
                    }
                });
            seq.Append(tween);
            seq.OnStart(() =>
                {
                    if (MoveStart != null)
                    {
                        MoveStart(this, EventArgs.Empty);
                    }
                });

            transform.position = path.From.position;
            seq.Play();
        }
    }
}