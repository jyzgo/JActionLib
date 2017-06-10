using UnityEngine;

namespace JUnity.Actions
{
    public class JDelayTime : JFiniteTimeAction
    {
        #region Constructors

        public JDelayTime (float duration) : base (duration)
        {
        }

        #endregion Constructors

        protected internal override JActionState StartAction(GameObject target)
        {
            return new JDelayTimeState (this, target);

        }

        public override JFiniteTimeAction Reverse ()
        {
            return new JDelayTime (Duration);
        }
    }

    public class JDelayTimeState : JFiniteTimeActionState
    {

        public JDelayTimeState (JDelayTime action, GameObject target)
            : base (action, target)
        {
        }

        public override void Update (float time)
        {
        }

    }
}