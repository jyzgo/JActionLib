using UnityEngine;

namespace JUnity.Actions
{
    public class JEaseRateAction : JActionEase
    {
        public float Rate { get; private set; }


        #region Constructors

        public JEaseRateAction (JFiniteTimeAction action, float rate) : base (action)
        {
            Rate = rate;
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new JEaseRateActionState (this, target);
        }

        public override JFiniteTimeAction Reverse ()
        {
            return new JEaseRateAction ((JFiniteTimeAction)InnerAction.Reverse (), 1 / Rate);
        }
    }


    #region Action state

    public class JEaseRateActionState : JActionEaseState
    {
        protected float Rate { get; private set; }

        public JEaseRateActionState (JEaseRateAction action, GameObject target) : base (action, target)
        {
            Rate = action.Rate;
        }

        public override void Update (float time)
        {
            InnerActionState.Update (JEaseMath.ExpoOut (time));
        }
    }

    #endregion Action state
}