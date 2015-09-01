using UnityEngine;

namespace MTUnityAction
{
    public class MTHide : MTActionInstant
    {
        #region Constructors

        public MTHide ()
        {
        }

        #endregion Constructors


        protected internal override MTActionState StartAction(GameObject target)
        {
            return new MTHideState (this, target);

        }

        public override MTFiniteTimeAction Reverse ()
        {
            return (new MTShow ());
        }

    }

    public class MTHideState : MTActionInstantState
    {

        public MTHideState (MTHide action, GameObject target)
            : base (action, target)
        {   
			var render = target.GetComponent<Renderer> ();
			if (render) {
				render.enabled = false;
			}
        }

    }

}