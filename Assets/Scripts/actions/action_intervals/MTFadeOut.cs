using UnityEngine;

namespace JUnity.Actions
{
    public class MTFadeOut : JFiniteTimeAction
    {
        #region Constructors

        public MTFadeOut (float durtaion) : base (durtaion)
        {
        }

        #endregion Constructors

        protected internal override JActionState StartAction(GameObject target)
        {
            return new MTFadeOutState (this, target);

        }

        public override JFiniteTimeAction Reverse ()
        {
            return new MTFadeIn (Duration);
        }
    }

    public class MTFadeOutState : JFiniteTimeActionState
    {

        public MTFadeOutState (MTFadeOut action, GameObject target)
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