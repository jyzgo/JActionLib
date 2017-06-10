using UnityEngine;

namespace JUnity.Actions
{
	public class JEaseCircOut : JActionEase
	{
		public JEaseCircOut (JFiniteTimeAction action) : base (action)
		{
		}

		protected internal override JActionState StartAction (GameObject target)
		{
			return new JEaseCircOutState (this, target);
		}

		public override JFiniteTimeAction Reverse ()
		{
			return new JEaseCircIn ((JFiniteTimeAction)InnerAction.Reverse ());
		}
	}

	public class JEaseCircOutState : JActionEaseState
	{
		public JEaseCircOutState (JEaseCircOut action, GameObject target) : base (action, target)
		{
		}

		public override void Update (float time)
		{
			InnerActionState.Update (JEaseMath.CircOut (time));
		}
	}

}