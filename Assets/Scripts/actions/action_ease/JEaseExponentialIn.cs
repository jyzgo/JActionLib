using System;

using UnityEngine;

namespace JUnity.Actions
{
    public class JEaseExponentialIn : JActionEase
    {
        #region Constructors

        public JEaseExponentialIn (JFiniteTimeAction action) : base (action)
        {
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new JEaseExponentialInState (this, target);
        }

        public override JFiniteTimeAction Reverse ()
        {
            return new JEaseExponentialOut ((JFiniteTimeAction)InnerAction.Reverse ());
        }
    }


    #region Action state

    public class JEaseExponentialInState : JActionEaseState
    {
        public JEaseExponentialInState (JEaseExponentialIn action, GameObject target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            InnerActionState.Update (JEaseMath.ExpoIn (time));
        }
    }

    #endregion Action state
}