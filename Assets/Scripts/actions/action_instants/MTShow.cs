using UnityEngine;

namespace JUnity.Actions
{
    public class MTShow : MTActionInstant
    {
        #region Constructors

        public MTShow ()
        {
        }

        #endregion Constructors

        protected internal override JActionState StartAction(GameObject target)
        {
            return new MTShowState (this, target);

        }

        public override JFiniteTimeAction Reverse ()
        {
            return (new MTHide ());
        }

    }

    public class MTShowState : MTActionInstantState
    {

        public MTShowState (MTShow action, GameObject target)
            : base (action, target)
        {   
			var render = target.GetComponent<Renderer> ();
			if (render) {
				render.enabled = true;
			}
        }

    }

}