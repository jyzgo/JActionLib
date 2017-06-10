using System;

using UnityEngine;

namespace JUnity.Actions
{
    public partial class JEaseCustom : JActionEase
    {
        public Func<float, float> EaseFunc { get; private set; }


        #region Constructors

        public JEaseCustom (JFiniteTimeAction action, Func<float, float> easeFunc) : base (action)
        {
            EaseFunc = easeFunc;
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new JEaseCustomState (this, target);
        }

        public override JFiniteTimeAction Reverse ()
        {
            return new JReverseTime (this);
        }
    }


    #region Action state

    public class JEaseCustomState : JActionEaseState
    {
        protected Func<float, float> EaseFunc { get; private set; }

        public JEaseCustomState (JEaseCustom action, GameObject target) : base (action, target)
        {
            EaseFunc = action.EaseFunc;
        }

        public override void Update (float time)
        {
            InnerActionState.Update (EaseFunc (time));
        }
    }

    #endregion Action state
}