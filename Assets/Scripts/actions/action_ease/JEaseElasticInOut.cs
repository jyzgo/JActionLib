using System;
//using Microsoft.Xna.Framework;



using UnityEngine;

namespace JUnity.Actions
{
    public class JEaseElasticInOut : JEaseElastic
    {
        #region Constructors

        public JEaseElasticInOut (JFiniteTimeAction action) : this (action, 0.3f)
        {
        }

        public JEaseElasticInOut (JFiniteTimeAction action, float period) : base (action, period)
        {
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new JEaseElasticInOutState (this, target);
        }

        public override JFiniteTimeAction Reverse ()
        {
            return new JEaseElasticInOut ((JFiniteTimeAction)InnerAction.Reverse (), Period);
        }
    }


    #region Action state

    public class JEaseElasticInOutState : JEaseElasticState
    {
        public JEaseElasticInOutState (JEaseElasticInOut action, GameObject target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            InnerActionState.Update (JEaseMath.ElasticInOut (time, Period));
        }
    }

    #endregion Action state
}