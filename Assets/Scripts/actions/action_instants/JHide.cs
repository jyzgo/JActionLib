using UnityEngine;

namespace JUnity.Actions
{
    public class JHide : JActionInstant
    {
        #region Constructors

        public JHide ()
        {
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new JHideState (this, target);

        }

        public override JFiniteTimeAction Reverse ()
        {
            return (new JShow ());
        }

    }

    public class JHideState : JActionInstantState
    {

        public JHideState (JHide action, GameObject target)
            : base (action, target)
        {   
			var render = target.GetComponent<Renderer> ();
			if (render) {
				var curColor =  render.material.color ;
				render.material.color = new Color(curColor.r,curColor.g,curColor.b,0f);
			}
        }

    }

}