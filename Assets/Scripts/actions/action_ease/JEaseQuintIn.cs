using UnityEngine;

namespace JUnity.Actions
{
	public class MTEaseQuintIn : MTActionEase
	{
		public MTEaseQuintIn (JFiniteTimeAction action) : base (action)
		{
		}

		protected internal override JActionState StartAction (GameObject target)
		{
			return new MTEaseQuintInState (this, target);
		}

		public override JFiniteTimeAction Reverse ()
		{
			return new MTEaseQuintOut ((JFiniteTimeAction)InnerAction.Reverse ());
		}
	}

	public class MTEaseQuintInState : MTActionEaseState
	{
		public MTEaseQuintInState (MTEaseQuintIn action, GameObject target) : base (action, target)
		{
		}

		public override void Update (float time)
		{
			InnerActionState.Update (MTEaseMath.QuintIn (time));
		}
	}

}