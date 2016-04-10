using UnityEngine;

namespace Chicken
{
    public class Path
	{
		private Transform from, to;

		public Path(Transform from, Transform to)
		{
			this.from = from;
			this.to = to;
		}

		public Transform From { get { return from; } }

		public Transform To { get { return to; } }

        public float Distance { get { return Vector3.Distance(from.position, to.position); } }
	}
}
