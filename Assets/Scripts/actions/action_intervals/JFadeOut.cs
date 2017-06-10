using UnityEngine;

namespace JUnity.Actions
{
    public class JFadeOut : JFiniteTimeAction
    {
        #region Constructors

        public JFadeOut (float durtaion) : base (durtaion)
        {
        }

        #endregion Constructors

        protected internal override JActionState StartAction(GameObject target)
        {
            return new JFadeOutState (this, target);

        }

        public override JFiniteTimeAction Reverse ()
        {
            return new JFadeIn (Duration);
        }
    }

    public class JFadeOutState : JFiniteTimeActionState
    {

        public JFadeOutState (JFadeOut action, GameObject target)
            : base (action, target)
        {
        }

        public override void Update (float time)
        {
            var pRGBAProtocol = Target;
            if (pRGBAProtocol != null)
            {
				pRGBAProtocol.setOpacity(1 - time);
            }
        }

    }

}