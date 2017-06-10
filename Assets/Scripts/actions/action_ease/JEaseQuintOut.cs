using UnityEngine;

namespace JUnity.Actions
{
	public class JEaseQuintOut : JActionEase
	{
		public JEaseQuintOut (JFiniteTimeAction action) : base (action)
		{
		}

		protected internal override JActionState StartAction (GameObject target)
		{
			return new JEaseQuintOutState (this, target);
		}

		public override JFiniteTimeAction Reverse ()
		{
			return new JEaseQuintIn ((JFiniteTimeAction)InnerAction.Reverse ());
		}
	}

	public class JEaseQuintOutState : JActionEaseState
	{
		public JEaseQuintOutState (JEaseQuintOut action, GameObject target) : base (action, target)
		{
		}

		public override void Update (float time)
		{
			InnerActionState.Update (JEaseMath.QuintOut (time));
		}
	}

}