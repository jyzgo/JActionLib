using System;
//using Microsoft.Xna.Framework;



using UnityEngine;

namespace JUnity.Actions
{
    public class MTEaseElasticOut : MTEaseElastic
    {
        #region Constructors

        public MTEaseElasticOut (JFiniteTimeAction action) : base (action, 0.3f)
        {
        }

        public MTEaseElasticOut (JFiniteTimeAction action, float period) : base (action, period)
        {
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new MTEaseElasticOutState (this, target);
        }

        public override JFiniteTimeAction Reverse ()
        {
            return new MTEaseElasticIn ((JFiniteTimeAction)InnerAction.Reverse(), Period);
        }
    }


    #region Action state

    public class MTEaseElasticOutState : MTEaseElasticState
    {
        public MTEaseElasticOutState (MTEaseElasticOut action, GameObject target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            InnerActionState.Update (MTEaseMath.ElasticOut (time, Period));
        }
    }

    #endregion Action state
}