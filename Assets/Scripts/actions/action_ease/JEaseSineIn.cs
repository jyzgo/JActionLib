using System;
//using Microsoft.Xna.Framework;



using UnityEngine;

namespace JUnity.Actions
{
	public class JEaseSineIn : JActionEase
	{
		#region Constructors

        public JEaseSineIn (JFiniteTimeAction action) : base (action)
		{
		}

		#endregion Constructors


		protected internal override JActionState StartAction(GameObject target)
		{
			return new JEaseSineInState (this, target);
		}

		public override JFiniteTimeAction Reverse ()
		{
            return new JEaseSineOut ((JFiniteTimeAction)InnerAction.Reverse ());
		}
	}


	#region Action state

	public class JEaseSineInState : JActionEaseState
	{
		public JEaseSineInState (JEaseSineIn action, GameObject target) : base (action, target)
		{
		}

		public override void Update (float time)
		{
			InnerActionState.Update (JEaseMath.SineIn (time));
		}
	}

	#endregion Action state
}