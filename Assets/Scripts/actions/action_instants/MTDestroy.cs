using System;
using System.Collections.Generic;

using UnityEngine;

namespace MTUnity.Actions
{
	public class MTDestroy : MTActionInstant
	{
		public bool IsNeedCleanUp { get; private set; }
		
		#region Constructors
		
		public MTDestroy ()
			: this (true)
		{
		}
		
		public MTDestroy (bool isNeedCleanUp)
		{
			IsNeedCleanUp = isNeedCleanUp;
		}
		
		#endregion Constructors
		
		
		protected internal override MTActionState StartAction(GameObject target)
		{
			return new MTDestroyState (this, target);
			
		}
		
		
		public override MTFiniteTimeAction Reverse ()
		{
			return new MTDestroy (IsNeedCleanUp);
		}
	}
	
	public class MTDestroyState : MTActionInstantState
	{
		protected bool IsNeedCleanUp { get; set; }
		
		public MTDestroyState (MTDestroy action, GameObject target)
			: base (action, target)
		{   
			IsNeedCleanUp = action.IsNeedCleanUp;
		}
		
		public override void Update (float time)
		{
			if (Target && Target.gameObject) 
			{
				UnityEngine.Object.Destroy(Target.gameObject);
			}
		}
		
	}
	
}