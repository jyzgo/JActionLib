using System;

using UnityEngine;

namespace JUnity.Actions
{
    public class MTEaseIn : MTEaseRateAction
    {
        #region Constructors

        public MTEaseIn (JFiniteTimeAction action, float rate) : base (action, rate)
        {
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new MTEaseInState (this, target);
        }

        public override JFiniteTimeAction Reverse ()
        {
            return new MTEaseIn ((JFiniteTimeAction)InnerAction.Reverse (), 1 / Rate);
        }
    }


    #region Action state

    public class MTEaseInState : MTEaseRateActionState
    {
        public MTEaseInState (MTEaseIn action, GameObject target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            InnerActionState.Update ((float)Math.Pow (time, Rate));
        }
    }

    #endregion Action state

}