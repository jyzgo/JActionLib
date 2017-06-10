using System;
//using Microsoft.Xna.Framework;



using UnityEngine;

namespace JUnity.Actions
{
    public class MTEaseElasticInOut : MTEaseElastic
    {
        #region Constructors

        public MTEaseElasticInOut (JFiniteTimeAction action) : this (action, 0.3f)
        {
        }

        public MTEaseElasticInOut (JFiniteTimeAction action, float period) : base (action, period)
        {
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new MTEaseElasticInOutState (this, target);
        }

        public override JFiniteTimeAction Reverse ()
        {
            return new MTEaseElasticInOut ((JFiniteTimeAction)InnerAction.Reverse (), Period);
        }
    }


    #region Action state

    public class MTEaseElasticInOutState : MTEaseElasticState
    {
        public MTEaseElasticInOutState (MTEaseElasticInOut action, GameObject target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            InnerActionState.Update (MTEaseMath.ElasticInOut (time, Period));
        }
    }

    #endregion Action state
}