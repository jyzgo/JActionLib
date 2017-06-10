using UnityEngine;

namespace JUnity.Actions
{
	public class JEaseCircInOut : JActionEase
	{
		public JEaseCircInOut (JFiniteTimeAction action) : base (action)
		{
		}

		protected internal override JActionState StartAction (GameObject target)
		{
			return new JEaseCircInOutState (this, target);
		}

		public override JFiniteTimeAction Reverse ()
		{
			return new JEaseCircInOut ((JFiniteTimeAction)InnerAction.Reverse ());
		}
	}

	public class JEaseCircInOutState : JActionEaseState
	{
		public JEaseCircInOutState (JEaseCircInOut action, GameObject target) : base (action, target)
		{
		}

		public override void Update (float time)
		{
			InnerActionState.Update (JEaseMath.CircInOut (time));
		}
	}

}