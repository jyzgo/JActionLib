using UnityEngine;

namespace JUnity.Actions
{
	public class JEaseQuadOut : JActionEase
	{
		public JEaseQuadOut (JFiniteTimeAction action) : base (action)
		{
		}

		protected internal override JActionState StartAction (GameObject target)
		{
			return new JEaseQuadOutState (this, target);
		}

		public override JFiniteTimeAction Reverse ()
		{
			return new JEaseQuadIn ((JFiniteTimeAction)InnerAction.Reverse ());
		}
	}

	public class JEaseQuadOutState : JActionEaseState
	{
		public JEaseQuadOutState (JEaseQuadOut action, GameObject target) : base (action, target)
		{
		}

		public override void Update (float time)
		{
			InnerActionState.Update (JEaseMath.QuadOut (time));
		}
	}

}