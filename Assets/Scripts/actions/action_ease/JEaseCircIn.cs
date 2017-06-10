using UnityEngine;

namespace JUnity.Actions
{
	public class JEaseCircIn : JActionEase
	{
		public JEaseCircIn (JFiniteTimeAction action) : base (action)
		{
		}

		protected internal override JActionState StartAction (GameObject target)
		{
			return new JEaseCircInState (this, target);
		}

		public override JFiniteTimeAction Reverse ()
		{
			return new JEaseCircOut ((JFiniteTimeAction)InnerAction.Reverse ());
		}
	}

	public class JEaseCircInState : JActionEaseState
	{
		public JEaseCircInState (JEaseCircIn action, GameObject target) : base (action, target)
		{
		}

		public override void Update (float time)
		{
			InnerActionState.Update (JEaseMath.CircIn (time));
		}
	}

}