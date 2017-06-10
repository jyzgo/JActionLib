using UnityEngine;

namespace JUnity.Actions
{
    public class JEaseElastic : JActionEase
    {
        public float Period { get; private set; }


        #region Constructors

        public JEaseElastic (JFiniteTimeAction action, float period) : base (action)
        {
            Period = period;
        }

        public JEaseElastic (JFiniteTimeAction action) : this (action, 0.3f)
        {
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new JEaseElasticState (this, target);
        }

        public override JFiniteTimeAction Reverse ()
        {
            return null;
        }
    }


    #region Action state

    public class JEaseElasticState : JActionEaseState
    {
        protected float Period { get; private set; }

        public JEaseElasticState (JEaseElastic action, GameObject target) : base (action, target)
        {
            Period = action.Period;
        }
    }

    #endregion Action state
}