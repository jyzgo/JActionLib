using UnityEngine;

namespace JUnity.Actions
{
	public class JEaseQuadInOut : JActionEase
	{
		public JEaseQuadInOut (JFiniteTimeAction action) : base (action)
		{
		}

		protected internal override JActionState StartAction (GameObject target)
		{
			return new JEaseQuadInOutState (this, target);
		}

		public override JFiniteTimeAction Reverse ()
		{
			return new JEaseQuadInOut ((JFiniteTimeAction)InnerAction.Reverse ());
		}
	}

	public class JEaseQuadInOutState : JActionEaseState
	{
		public JEaseQuadInOutState (JEaseQuadInOut action, GameObject target) : base (action, target)
		{
		}

		public override void Update (float time)
		{
			InnerActionState.Update (JEaseMath.QuadInOut (time));
		}
	}

}