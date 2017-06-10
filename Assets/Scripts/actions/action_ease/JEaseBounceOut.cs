using UnityEngine;

namespace JUnity.Actions
{
    public class JEaseBounceOut : JActionEase
    {
        #region Constructors

        public JEaseBounceOut (JFiniteTimeAction action) : base (action)
        {
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new JEaseBounceOutState (this, target);
        }

        public override JFiniteTimeAction Reverse ()
        {
            return new JEaseBounceIn ((JFiniteTimeAction)InnerAction.Reverse ());
        }
    }


    #region Action state

    public class JEaseBounceOutState : JActionEaseState
    {
        public JEaseBounceOutState (JEaseBounceOut action, GameObject target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            InnerActionState.Update (JEaseMath.BounceOut (time));
        }
    }

    #endregion Action state
}