using System;
//using Microsoft.Xna.Framework;



using UnityEngine;

namespace JUnity.Actions
{
    public class JEaseElasticIn : JEaseElastic
    {
        #region Constructors

        public JEaseElasticIn (JFiniteTimeAction action) : this (action, 0.3f)
        {
        }

        public JEaseElasticIn (JFiniteTimeAction action, float period) : base (action, period)
        {
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new JEaseElasticInState (this, target);
        }

        public override JFiniteTimeAction Reverse ()
        {
            return new JEaseElasticOut ((JFiniteTimeAction)InnerAction.Reverse (), Period);
        }
    }


    #region Action state

    public class JEaseElasticInState : JEaseElasticState
    {
        public JEaseElasticInState (JEaseElasticIn action, GameObject target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            InnerActionState.Update (JEaseMath.ElasticIn (time, Period));
        }
    }

    #endregion Action state
}