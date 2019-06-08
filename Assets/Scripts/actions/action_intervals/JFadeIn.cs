using System;
using UnityEngine;

namespace JUnity.Actions
{
    public class JFadeIn : JFiniteTimeAction
    {
        #region Constructors

        [ObsoleteAttribute("This method will soon be deprecated. Use JGraphicFadeTo")]
        public JFadeIn (float durataion) : base (durataion)
        {
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new JFadeInState (this, target);

        }

        public override JFiniteTimeAction Reverse ()
        {
            return new JFadeOut (Duration);
        }
    }

    public class JFadeInState : JFiniteTimeActionState
    {

        protected uint Times { get; set; }

        protected bool OriginalState { get; set; }

        public JFadeInState (JFadeIn action, GameObject target)
            : base (action, target)
        {
        }

        public override void Update (float time)
        {
            var pRGBAProtocol = Target;
            if (pRGBAProtocol != null)
            {
//                pRGBAProtocol.Opacity = (byte)(255 * time);
				pRGBAProtocol.setOpacity(time);
            }
        }
    }

}