using System;

using UnityEngine;

namespace JUnity.Actions
{
    public class JEaseOut : JEaseRateAction
    {
        #region Constructors

        public JEaseOut (JFiniteTimeAction action, float rate) : base (action, rate)
        {
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new JEaseOutState (this, target);
        }

        public override JFiniteTimeAction Reverse ()
        {
            return new JEaseOut ((JFiniteTimeAction)InnerAction.Reverse (), 1 / Rate);
        }
    }


    #region Action state

    public class JEaseOutState : JEaseRateActionState
    {
        public JEaseOutState (JEaseOut action, GameObject target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            InnerActionState.Update ((float)(Math.Pow (time, 1 / Rate)));      
        }
    }

    #endregion Action state
}