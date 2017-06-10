using System;
//using Microsoft.Xna.Framework;



using UnityEngine;

namespace JUnity.Actions
{
    public class JEaseElasticOut : JEaseElastic
    {
        #region Constructors

        public JEaseElasticOut (JFiniteTimeAction action) : base (action, 0.3f)
        {
        }

        public JEaseElasticOut (JFiniteTimeAction action, float period) : base (action, period)
        {
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new JEaseElasticOutState (this, target);
        }

        public override JFiniteTimeAction Reverse ()
        {
            return new JEaseElasticIn ((JFiniteTimeAction)InnerAction.Reverse(), Period);
        }
    }


    #region Action state

    public class JEaseElasticOutState : JEaseElasticState
    {
        public JEaseElasticOutState (JEaseElasticOut action, GameObject target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            InnerActionState.Update (JEaseMath.ElasticOut (time, Period));
        }
    }

    #endregion Action state
}