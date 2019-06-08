using UnityEngine;

namespace JUnity.Actions
{
    public class JEnabled: JActionInstant
    {
     

        protected internal override JActionState StartAction(GameObject target)
        {
            return new JEnabledState(this, target);

        }

        public override JFiniteTimeAction Reverse ()
        {
            return (new JShow ());
        }

    }

    public class JEnabledState: JActionInstantState
    {

        public JEnabledState(JEnabled action, GameObject target)
            : base (action, target)
        {
            if (target != null)
            {
                target.SetActive(true);
            }
        }

    }

}
