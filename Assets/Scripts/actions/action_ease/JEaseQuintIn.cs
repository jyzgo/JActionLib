using UnityEngine;

namespace JUnity.Actions
{
	public class JEaseQuintIn : JActionEase
	{
		public JEaseQuintIn (JFiniteTimeAction action) : base (action)
		{
		}

		protected internal override JActionState StartAction (GameObject target)
		{
			return new JEaseQuintInState (this, target);
		}

		public override JFiniteTimeAction Reverse ()
		{
			return new JEaseQuintOut ((JFiniteTimeAction)InnerAction.Reverse ());
		}
	}

	public class JEaseQuintInState : JActionEaseState
	{
		public JEaseQuintInState (JEaseQuintIn action, GameObject target) : base (action, target)
		{
		}

		public override void Update (float time)
		{
			InnerActionState.Update (JEaseMath.QuintIn (time));
		}
	}

}