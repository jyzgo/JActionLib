using System;
//using Microsoft.Xna.Framework;



using UnityEngine;

namespace JUnity.Actions
{
	public class MTEaseSineIn : MTActionEase
	{
		#region Constructors

        public MTEaseSineIn (JFiniteTimeAction action) : base (action)
		{
		}

		#endregion Constructors


		protected internal override JActionState StartAction(GameObject target)
		{
			return new MTEaseSineInState (this, target);
		}

		public override JFiniteTimeAction Reverse ()
		{
            return new MTEaseSineOut ((JFiniteTimeAction)InnerAction.Reverse ());
		}
	}


	#region Action state

	public class MTEaseSineInState : MTActionEaseState
	{
		public MTEaseSineInState (MTEaseSineIn action, GameObject target) : base (action, target)
		{
		}

		public override void Update (float time)
		{
			InnerActionState.Update (MTEaseMath.SineIn (time));
		}
	}

	#endregion Action state
}