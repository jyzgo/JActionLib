using UnityEngine;

namespace JUnity.Actions
{
	public class JEaseQuartInOut : JActionEase
	{
		public JEaseQuartInOut (JFiniteTimeAction action) : base (action)
		{
		}

		protected internal override JActionState StartAction (GameObject target)
		{
			return new JEaseQuartInOutState (this, target);
		}

		public override JFiniteTimeAction Reverse ()
		{
			return new JEaseQuartInOut ((JFiniteTimeAction)InnerAction.Reverse ());
		}
	}

	public class JEaseQuartInOutState : JActionEaseState
	{
		public JEaseQuartInOutState (JEaseQuartInOut action, GameObject target) : base (action, target)
		{
		}

		public override void Update (float time)
		{
			InnerActionState.Update (JEaseMath.QuartInOut (time));
		}
	}

}