using UnityEngine;

namespace JUnity.Actions
{
    public class MTEaseElastic : MTActionEase
    {
        public float Period { get; private set; }


        #region Constructors

        public MTEaseElastic (JFiniteTimeAction action, float period) : base (action)
        {
            Period = period;
        }

        public MTEaseElastic (JFiniteTimeAction action) : this (action, 0.3f)
        {
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new MTEaseElasticState (this, target);
        }

        public override JFiniteTimeAction Reverse ()
        {
            return null;
        }
    }


    #region Action state

    public class MTEaseElasticState : MTActionEaseState
    {
        protected float Period { get; private set; }

        public MTEaseElasticState (MTEaseElastic action, GameObject target) : base (action, target)
        {
            Period = action.Period;
        }
    }

    #endregion Action state
}