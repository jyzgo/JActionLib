using UnityEngine;

namespace JUnity.Actions
{
    public class JDisabled: JActionInstant
    {
        #region Constructors

        public  JDisabled()
        {
        }

        #endregion Constructors


        protected internal override JActionState StartAction(GameObject target)
        {
            return new JDisabledState(this, target);

        }

        public override JFiniteTimeAction Reverse ()
        {
            return (new JShow ());
        }

    }

    public class JDisabledState: JActionInstantState
    {

        public JDisabledState(JDisabled action, GameObject target)
            : base (action, target)
        {
            if (target != null)
            {
                target.SetActive(false);
            }
        }

    }

}
