using System;

using UnityEngine;

namespace JUnity.Actions
{
    public class JEaseExponentialInOut : JActionEase
    {
        #region Constructors

        public JEaseExponentialInOut (JFiniteTimeAction action) : base(action)
        {
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new JEaseExponentialInOutState (this, target);
        }

        public override JFiniteTimeAction Reverse ()
        {
            return new JEaseExponentialInOut ((JFiniteTimeAction)InnerAction.Reverse ());
        }
    }


    #region Action state

    public class JEaseExponentialInOutState : JActionEaseState
    {
        public JEaseExponentialInOutState (JEaseExponentialInOut action, GameObject target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            InnerActionState.Update (JEaseMath.ExpoInOut (time));
        }
    }

    #endregion Action state
}