using System;

using UnityEngine;

namespace JUnity.Actions
{
    public class JEaseSineOut : JActionEase
    {
        #region Constructors

        public JEaseSineOut (JFiniteTimeAction action) : base (action)
        {
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new JEaseSineOutState (this, target);
        }

        public override JFiniteTimeAction Reverse ()
        {
            return new JEaseSineIn ((JFiniteTimeAction)InnerAction.Reverse ());
        }
    }


    #region Action state

    public class JEaseSineOutState : JActionEaseState
    {
        public JEaseSineOutState (JEaseSineOut action, GameObject target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            InnerActionState.Update (JEaseMath.SineOut (time));
        }
    }

    #endregion Action state
}