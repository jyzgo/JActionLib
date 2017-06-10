using UnityEngine;

namespace JUnity.Actions
{
    public class JMoveBy : JFiniteTimeAction
    {
        #region Constructors

        public JMoveBy (float duration, Vector3 position) : base (duration)
        {
            PositionDelta = position;
        }

        #endregion Constructors

        public Vector3 PositionDelta { get; private set; }

        protected internal override JActionState StartAction(GameObject target)
        {
            return new JMoveByState (this, target);
        }

        public override JFiniteTimeAction Reverse ()
        {
			return new JMoveBy (Duration, new Vector3 (-PositionDelta.x, -PositionDelta.y,-PositionDelta.z));
        }
    }

    public class JMoveByState : JFiniteTimeActionState
    {
        protected Vector3 PositionDelta;
        protected Vector3 EndPosition;
        protected Vector3 StartPosition;
		public Vector3 PreviousPosition {
			get;
			protected set;
		}

        public JMoveByState (JMoveBy action, GameObject target)
            : base (action, target)
        { 
			PositionDelta = action.PositionDelta;
			if(target == null)
			{
				return;
			}
			PreviousPosition = StartPosition = target.transform.localPosition;
        }

        public override void Update (float time)
        {
            if (Target == null)
                return;

			var currentPos = Target.transform.localPosition;
            var diff = currentPos - PreviousPosition;
            StartPosition = StartPosition + diff;
			Vector3 newPos = StartPosition + PositionDelta * time;
			PreviousPosition = newPos;
			Target.transform.localPosition = newPos;
        }
    }

}