using UnityEngine;

namespace JUnity.Actions
{
    public class MTFadeIn : JFiniteTimeAction
    {
        #region Constructors

        public MTFadeIn (float durataion) : base (durataion)
        {
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new MTFadeInState (this, target);

        }

        public override JFiniteTimeAction Reverse ()
        {
            return new MTFadeOut (Duration);
        }
    }

    public class MTFadeInState : JFiniteTimeActionState
    {

        protected uint Times { get; set; }

        protected bool OriginalState { get; set; }

        public MTFadeInState (MTFadeIn action, GameObject target)
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