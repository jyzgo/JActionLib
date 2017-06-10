using System;

using UnityEngine;

namespace JUnity.Actions
{
    public class MTEaseOut : MTEaseRateAction
    {
        #region Constructors

        public MTEaseOut (JFiniteTimeAction action, float rate) : base (action, rate)
        {
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new MTEaseOutState (this, target);
        }

        public override JFiniteTimeAction Reverse ()
        {
            return new MTEaseOut ((JFiniteTimeAction)InnerAction.Reverse (), 1 / Rate);
        }
    }


    #region Action state

    public class MTEaseOutState : MTEaseRateActionState
    {
        public MTEaseOutState (MTEaseOut action, GameObject target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            InnerActionState.Update ((float)(Math.Pow (time, 1 / Rate)));      
        }
    }

    #endregion Action state
}