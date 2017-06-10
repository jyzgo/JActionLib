using System;

using UnityEngine;

namespace JUnity.Actions
{
    public class JEaseExponentialOut : JActionEase
    {
        #region Constructors

        public JEaseExponentialOut (JFiniteTimeAction action) : base (action)
        {
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new JEaseExponentialOutState (this, target);
        }

        public override JFiniteTimeAction Reverse ()
        {
            return new JEaseExponentialIn ((JFiniteTimeAction)InnerAction.Reverse ());
        }
    }


    #region Action state

    public class JEaseExponentialOutState : JActionEaseState
    {
        public JEaseExponentialOutState (JEaseExponentialOut action, GameObject target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            InnerActionState.Update (JEaseMath.ExpoOut (time));
        }
    }

    #endregion Action state
}