using UnityEngine;

namespace JUnity.Actions
{
    public class MTDelayTime : JFiniteTimeAction
    {
        #region Constructors

        public MTDelayTime (float duration) : base (duration)
        {
        }

        #endregion Constructors

        protected internal override JActionState StartAction(GameObject target)
        {
            return new MTDelayTimeState (this, target);

        }

        public override JFiniteTimeAction Reverse ()
        {
            return new MTDelayTime (Duration);
        }
    }

    public class MTDelayTimeState : JFiniteTimeActionState
    {

        public MTDelayTimeState (MTDelayTime action, GameObject target)
            : base (action, target)
        {
        }

        public override void Update (float time)
        {
        }

    }
}