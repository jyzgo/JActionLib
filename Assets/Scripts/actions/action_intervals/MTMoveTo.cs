using UnityEngine;

namespace MTUnity.Actions
{
    public class MTMoveTo : MTMoveBy
    {
        protected Vector3 EndPosition;

        #region Constructors

        public MTMoveTo (float duration, Vector3 position) : base (duration, position)
        {
            EndPosition = position;
        }
        public static MTFiniteTimeAction Create(float duration,MonoBehaviour curMono)
        {
            if (curMono == null || curMono.gameObject == null)
                return null;
            var curTaget = curMono.gameObject.transform.localPosition;

            var curMove = new MTMoveTo (duration, curTaget);
            return curMove;
        }

        #endregion Constructors

        public Vector3 PositionEnd {
            get { return EndPosition; }
        }

        protected internal override MTActionState StartAction(GameObject target)
        {
            return new MTMoveToState (this, target);

        }
    }

    public class MTMoveToState : MTMoveByState
    {

        public MTMoveToState (MTMoveTo action, GameObject target)
            : base (action, target)
        { 
			StartPosition = target.transform.localPosition;
			PositionDelta = action.PositionEnd - target.transform.localPosition;
        }

        public override void Update (float time)
        {
            if (Target != null)
            {
                Vector3 newPos = StartPosition + PositionDelta * time;
				Target.transform.localPosition = newPos;
                PreviousPosition = newPos;
            }
        }
    }

}