using System;

using UnityEngine;

namespace JUnity.Actions
{
    public class JFadeTo : JFiniteTimeAction
    {
        public float ToOpacity { get; private set; }


        #region Constructors

        [ObsoleteAttribute("This method will soon be deprecated. Use JGraphicFadeTo")]
        public JFadeTo (float duration, float opacity) : base (duration)
        {
            ToOpacity = opacity;
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new JFadeToState (this, target);

        }

        public override JFiniteTimeAction Reverse()
        {
            throw new NotImplementedException();
        }
    }

    public class JFadeToState : JFiniteTimeActionState
    {
		protected float FromOpacity { get; set; }

		protected float ToOpacity { get; set; }

        public JFadeToState (JFadeTo action, GameObject target)
            : base (action, target)
        {              
            ToOpacity = action.ToOpacity;

            var pRGBAProtocol = target;
            if (pRGBAProtocol != null)
            {
				FromOpacity = pRGBAProtocol.getOpacity();
            }
        }

        public override void Update (float time)
        {
            var pRGBAProtocol = Target;
            if (pRGBAProtocol != null)
            {
				pRGBAProtocol.setOpacity (FromOpacity + (ToOpacity - FromOpacity) * time);
            }
        }
    }


}