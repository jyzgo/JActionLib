using System;

using UnityEngine;

namespace JUnity.Actions
{
    public class JEaseIn : JEaseRateAction
    {
        #region Constructors

        public JEaseIn (JFiniteTimeAction action, float rate) : base (action, rate)
        {
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new JEaseInState (this, target);
        }

        public override JFiniteTimeAction Reverse ()
        {
            return new JEaseIn ((JFiniteTimeAction)InnerAction.Reverse (), 1 / Rate);
        }
    }


    #region Action state

    public class JEaseInState : JEaseRateActionState
    {
        public JEaseInState (JEaseIn action, GameObject target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            InnerActionState.Update ((float)Math.Pow (time, Rate));
        }
    }

    #endregion Action state

}