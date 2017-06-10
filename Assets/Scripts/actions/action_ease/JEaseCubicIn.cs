using UnityEngine;

namespace JUnity.Actions
{
	public class JEaseCubicIn : JActionEase
	{
		public JEaseCubicIn (JFiniteTimeAction action) : base (action)
		{
		}

		protected internal override JActionState StartAction (GameObject target)
		{
			return new JEaseCubicInState (this, target);
		}

		public override JFiniteTimeAction Reverse ()
		{
			return new JEaseCubicOut ((JFiniteTimeAction)InnerAction.Reverse ());
		}
	}

	public class JEaseCubicInState : JActionEaseState
	{
		public JEaseCubicInState (JEaseCubicIn action, GameObject target) : base (action, target)
		{
		}

		public override void Update (float time)
		{
			InnerActionState.Update (JEaseMath.CubicIn (time));
		}
	}

}