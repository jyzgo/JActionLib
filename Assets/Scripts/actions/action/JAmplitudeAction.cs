using System;
using UnityEngine;


namespace JUnity.Actions
{
    public abstract class JAmplitudeAction : JFiniteTimeAction
    {
        public float Amplitude { get; private set; }


        #region Constructors

        public JAmplitudeAction (float duration, float amplitude = 0) : base (duration)
        {
            Amplitude = amplitude;
        }

        #endregion Constructors
    }


    #region Action state

    public abstract class JAmplitudeActionState : JFiniteTimeActionState
    {
        protected float Amplitude { get; private set; }
        protected internal float AmplitudeRate { get; set; }

        public JAmplitudeActionState (JAmplitudeAction action, GameObject target) : base (action, target)
        {
            Amplitude = action.Amplitude;
            AmplitudeRate = 1.0f;
        }
    }

    #endregion Action state
}
