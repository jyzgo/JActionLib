using UnityEngine;

namespace JUnity.Actions
{
	public class JEaseQuintInOut : JActionEase
	{
		public JEaseQuintInOut (JFiniteTimeAction action) : base (action)
		{
		}

		protected internal override JActionState StartAction (GameObject target)
		{
			return new JEaseQuintInOutState (this, target);
		}

		public override JFiniteTimeAction Reverse ()
		{
			return new JEaseQuintInOut ((JFiniteTimeAction)InnerAction.Reverse ());
		}
	}

	public class JEaseQuintInOutState : JActionEaseState
	{
		public JEaseQuintInOutState (JEaseQuintInOut action, GameObject target) : base (action, target)
		{
		}

		public override void Update (float time)
		{
			InnerActionState.Update (JEaseMath.QuintInOut (time));
		}
	}

}