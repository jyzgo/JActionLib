using System;
//using Microsoft.Xna.Framework;



using UnityEngine;

namespace JUnity.Actions
{
    public class MTEaseElasticIn : MTEaseElastic
    {
        #region Constructors

        public MTEaseElasticIn (JFiniteTimeAction action) : this (action, 0.3f)
        {
        }

        public MTEaseElasticIn (JFiniteTimeAction action, float period) : base (action, period)
        {
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new MTEaseElasticInState (this, target);
        }

        public override JFiniteTimeAction Reverse ()
        {
            return new MTEaseElasticOut ((JFiniteTimeAction)InnerAction.Reverse (), Period);
        }
    }


    #region Action state

    public class MTEaseElasticInState : MTEaseElasticState
    {
        public MTEaseElasticInState (MTEaseElasticIn action, GameObject target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            InnerActionState.Update (MTEaseMath.ElasticIn (time, Period));
        }
    }

    #endregion Action state
}