using UnityEngine;

namespace JUnity.Actions
{
    public class JToggleVisibility : JActionInstant
    {
        #region Constructors

        public JToggleVisibility ()
        {
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new JToggleVisibilityState (this, target);

        }
    }

    public class JToggleVisibilityState : JActionInstantState
    {

        public JToggleVisibilityState (JToggleVisibility action, GameObject target)
            : base (action, target)
        {   
			var render = target.GetComponent<Renderer> ();
			if (render) {
				render.enabled = !render.enabled;
			}
        }

    }

}