using UnityEngine;

namespace JUnity.Actions
{
    public class JEaseBounceInOut : JActionEase
    {
        #region Constructors

        public JEaseBounceInOut (JFiniteTimeAction action) : base (action)
        {
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new JEaseBounceInOutState (this, target);
        }

        public override JFiniteTimeAction Reverse ()
        {
            return new JEaseBounceInOut ((JFiniteTimeAction)InnerAction.Reverse ());
        }
    }


    #region Action state

    public class JEaseBounceInOutState : JActionEaseState
    {
        public JEaseBounceInOutState (JEaseBounceInOut action, GameObject target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            InnerActionState.Update (JEaseMath.BounceInOut (time));
        }
    }

    #endregion Action state
}