using UnityEngine;

namespace JUnity.Actions
{
    public class JShow : JActionInstant
    {
        #region Constructors

        public JShow ()
        {
        }

        #endregion Constructors

        protected internal override JActionState StartAction(GameObject target)
        {
            return new JShowState (this, target);

        }

        public override JFiniteTimeAction Reverse ()
        {
            return (new JHide ());
        }

    }

    public class JShowState : JActionInstantState
    {

        public JShowState (JShow action, GameObject target)
            : base (action, target)
        {   
			var render = target.GetComponent<Renderer> ();
			if (render) {
				render.enabled = true;
			}
        }

    }

}